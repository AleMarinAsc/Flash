using System.Collections;
using UnityEngine;

public class Ladrido : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    public float Speed;
    private Vector2 Direccion;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direccion * Speed;
        transform.localScale = new Vector3((Direccion == Vector2.right ? 0.19f : -0.19f), 0.19f, 1f);
    }

    public void SetDireccion(Vector2 direccion)
    {
        Direccion = direccion;
    }

    public void DestroyLadrido()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SerpienteScript Serpiente = collision.GetComponent<SerpienteScript>();
        RataScript Rata = collision.GetComponent<RataScript>();

        Debug.Log(Rata != null);

        if (Serpiente != null)
        {
            Serpiente.Hit();
        }

        if (Rata != null)
        {
            Rata.Hit();
        }

        DestroyLadrido();
    }
}
