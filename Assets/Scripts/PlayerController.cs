using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerController player;
    public bool grounded;

    public GameObject ladridoPrefab;
    public Transform shootPos;
    private Rigidbody2D rb2d;
    private Animator anim;
    private int Health = 3;

    private bool jump;
    private bool doubleJump;

    private float maxSpeed = 5f;
    private float jumpPower = 6.7f;
    private float lastShoot;

    public float speed = 2f;
    public float maxEnergy = 100f;

    public Image corazon1;
    public Image corazon2;
    public Image corazon3;

    [SerializeField] private SimpleFlash flashEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
        anim = GetComponent<Animator>();
        player = GetComponentInParent<PlayerController>();
        
        corazon1 = GameObject.Find("Corazon1").GetComponent<Image>();
        corazon2 = GameObject.Find("Corazon2").GetComponent<Image>();
        corazon3 = GameObject.Find("Corazon3").GetComponent<Image>();
        
        corazon1.enabled = true;
        corazon2.enabled = true;
        corazon3.enabled = true;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                jump = true;
                doubleJump = false;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            BarraDeEnergia.instance.UsarEnergia(0.1f);
        }

        if (Input.GetKeyDown(KeyCode.P) && BarraDeEnergia.instance.energiaActual >= 50  && Time.time > lastShoot + 0.45f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (BarraDeEnergia.instance.energiaActual >= 1)
        {
            rb2d.AddForce(Vector2.right * speed * h);
        }

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 1f);
        }

        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void Shoot()
    {
        BarraDeEnergia.instance.UsarEnergia(5f);

        Vector3 direccion;
        direccion = transform.localScale.x != 0.25f ? Vector2.right : Vector2.left;

        GameObject ladrido = Instantiate(ladridoPrefab, shootPos.position + direccion * 0.1f, Quaternion.identity);
        ladrido.GetComponent<Ladrido>().SetDireccion(direccion);
    }

    public void Hit()
    {
        Health = Health - 1;

        flashEffect.Flash();

        if(Health == 2)
        {
            corazon3.enabled = false;
        }
        else if (Health == 1)
        {
            corazon2.enabled = false;
        }
        else if (Health == 0)
        {
            corazon1.enabled = false;
            Destroy(gameObject);
            ControladorPerder.instance.Perder();
        }
    }
}
