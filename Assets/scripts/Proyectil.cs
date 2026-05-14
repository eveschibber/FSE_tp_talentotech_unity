using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 15f;
    public float tiempoDeVida = 3f;

    void Start()
    {
        // Se destruye sola después de 3 segundos para no llenar la memoria
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        // Se mueve hacia la derecha constantemente
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si choca con un ciervo (usando el Tag que ya creamos)
        if (collision.CompareTag("Ciervo"))
        {
            Destroy(collision.gameObject); // Destruye al ciervo
            Destroy(gameObject);           // Se destruye la bola de fuego
        }
    }
}