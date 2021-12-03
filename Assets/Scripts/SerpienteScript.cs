using UnityEngine;

public class SerpienteScript : MonoBehaviour
{
    public GameObject Flash;

    private float lastShoot;
    public GameObject venenoPrefab;
    public Transform shootPos;

    private int Health = 1;

    private void Update()
    {
        if (Flash == null) return;

        Vector3 direction = Flash.transform.position - transform.position;
        transform.localScale = direction.x >= 0.0f ? new Vector3(-0.55f, 0.70f, 1.0f) : new Vector3(0.55f, 0.70f, 1.0f);

        float distance = Mathf.Abs(Flash.transform.position.x - transform.position.x);

        if(distance < 4.3f && Time.time > lastShoot + 0.85f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direccion;
        direccion = transform.localScale.x != 0.55f ? Vector2.right : Vector2.left;
        GameObject veneno = Instantiate(venenoPrefab, shootPos.position + direccion * 0.1f, Quaternion.identity);
        veneno.GetComponent<Veneno>().SetDireccion(direccion);
    }

    public void Hit()
    {
        Health = Health - 1;
        if(Health == 0)
        {
            Score.instance.AumentarScore(5);
            Destroy(gameObject);
        }
    }
}
