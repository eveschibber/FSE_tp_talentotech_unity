using UnityEngine;
using UnityEngine.SceneManagement; // <-- IMPORTANTE: Librería para reiniciar el juego

public class PlayerController : MonoBehaviour
{
    public float fuerzaSalto = 50f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool estaEnSuelo = true;
    private bool juegoEmpezado = false;

    public GameObject prefabaBolaFuego; // Aquí arrastraremos el prefab
    public Transform puntoDisparo;      // Un objeto vacío para saber de dónde sale
    // --- VARIABLES DE AUDIO ---
    private AudioSource miAudio;
    public AudioClip sonidoSalto;
    public AudioClip sonidoDisparo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            if (Input.GetButtonDown("Jump") && estaEnSuelo)
            {
                rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                estaEnSuelo = false;
                anim.SetBool("estaEnSuelo", false);
                anim.SetTrigger("saltar");

                if (sonidoSalto != null) 
                {
                    miAudio.PlayOneShot(sonidoSalto);
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("disparar");

                // CREAR LA BOLA DE FUEGO
                Instantiate(prefabaBolaFuego, puntoDisparo.position, puntoDisparo.rotation);

                if (sonidoDisparo != null) 
                {
                    miAudio.PlayOneShot(sonidoDisparo);
                }
            }
        }
    }

private void OnCollisionEnter2D(Collision2D collision) 
    {
        // Detectar Suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
            anim.SetBool("estaEnSuelo", true);
        }

        // --- DETECTAR ENEMIGO O FAUNA NATIVA (Cualquiera te hace perder) ---
        // Usamos || que significa "O" en programación
        if (collision.gameObject.CompareTag("Axis") || collision.gameObject.CompareTag("Corzuela"))
        {
            Debug.Log("¡El Guardaparque chocó contra un animal! Reiniciando...");
            
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}