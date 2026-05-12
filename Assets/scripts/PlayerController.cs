using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fuerzaSalto = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool estaEnSuelo = true;
    private bool juegoEmpezado = false;

    // --- VARIABLES DE AUDIO ---
    private AudioSource miAudio;
    public AudioClip sonidoSalto;
    public AudioClip sonidoDisparo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // Buscamos el componente de audio al inicio
        miAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!juegoEmpezado && Input.GetKeyDown(KeyCode.Space))
        {
            juegoEmpezado = true;
            anim.SetBool("juegoEmpezado", true);
        }

        if (juegoEmpezado)
        {
            // Saltar
            if (Input.GetButtonDown("Jump") && estaEnSuelo)
            {
                rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                estaEnSuelo = false;
                anim.SetBool("estaEnSuelo", false);
                anim.SetTrigger("saltar");

                // REPRODUCIR SONIDO SALTO
                if (sonidoSalto != null) 
                {
                    miAudio.PlayOneShot(sonidoSalto);
                }
            }

            // Disparar
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("disparar");

                // REPRODUCIR SONIDO DISPARO
                if (sonidoDisparo != null) 
                {
                    // Usamos PlayOneShot para que el sonido no se corte si disparás rápido
                    miAudio.PlayOneShot(sonidoDisparo);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
            anim.SetBool("estaEnSuelo", true);
        }
    }
}