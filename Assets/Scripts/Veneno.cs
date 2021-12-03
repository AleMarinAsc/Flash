using UnityEngine;

public class Veneno : MonoBehaviour
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
        transform.localScale = new Vector3((Direccion == Vector2.right ? -0.22f : 0.22f), 0.22f, 1f);
    }

    public void SetDireccion(Vector2 direccion)
    {
        Direccion = direccion;
    }

    public void DestroyVeneno()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       PlayerController Flash = collision.GetComponent<PlayerController>();

        if (Flash != null)
        {
            Flash.Hit();
        }

        DestroyVeneno();
    }
}

