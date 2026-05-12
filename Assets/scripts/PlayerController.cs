using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fuerzaSalto = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool estaEnSuelo = true;
    private bool juegoEmpezado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Iniciar el juego al presionar cualquier tecla
       if (!juegoEmpezado && Input.GetKeyDown(KeyCode.Space))
        {
            juegoEmpezado = true;
            anim.SetBool("juegoEmpezado", true);
        }

        if (juegoEmpezado)
        {
            // Saltar con Barra Espaciadora
            if (Input.GetButtonDown("Jump") && estaEnSuelo)
            {
                rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                estaEnSuelo = false;
                anim.SetBool("estaEnSuelo", false);
                anim.SetTrigger("saltar");
            }

            // Disparar con la tecla F
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("disparar");
            }
        }
    }

    // ESTA ES LA PARTE DEL ERROR:
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
            anim.SetBool("estaEnSuelo", true);
        }
    }
}