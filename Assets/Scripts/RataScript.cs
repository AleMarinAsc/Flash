using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataScript : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator animator;
    public int direccion;
    public float speed;
    public GameObject Flash;
    public float rangoVision;
    private Rigidbody2D rb2d;
    private int Health = 0;
    private float lastShoot;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Comportamientos();
    }

    public void Comportamientos()
    {
        if (Flash != null)
        {
            if (Mathf.Abs(transform.position.x - Flash.transform.position.x) > rangoVision)
            {
                cronometro += 1 * Time.deltaTime;
                if (cronometro >= 3)
                {
                    rutina = Random.Range(0, 1);
                    cronometro = 0;
                }

                switch (rutina)
                {
                    case 0:
                        animator.SetBool("Caminar", false);
                        break;

                    case 1:
                        direccion = Random.Range(0, 1);
                        rutina++;
                        break;

                    case 2:
                        switch (direccion)
                        {
                            case 0:
                                transform.rotation = Quaternion.Euler(0, 0, 0);
                                transform.Translate(Vector3.right * speed * Time.deltaTime);
                                break;
                            case 1:
                                transform.rotation = Quaternion.Euler(0, 180, 0);
                                transform.Translate(Vector3.right * speed * Time.deltaTime);
                                break;
                        }
                        animator.SetBool("Caminar", true);
                        break;
                }
            }
            else
            {
                if (transform.position.x < Flash.transform.position.x)
                {
                    animator.SetBool("Caminar", true);
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    animator.SetBool("Caminar", true);
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }
    }

    public void Hit()
    {
        Health = Health - 1;

        if (Health <= 0)
        {
            Score.instance.AumentarScore(10/2);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController Flash = collision.GetComponent<PlayerController>();

        if (Flash != null && Time.time > lastShoot + 0.350f)
        {
            Flash.Hit();
            lastShoot = Time.time;
        }
    }
}