using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 15f;
    public float tiempoDeVida = 3f;

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // SI LE PEGA A UN AXIS (Exótico Invasor) -> BUENO
        if (collision.CompareTag("Axis"))
        {
            if (GameManager.instancia != null)
            {
                GameManager.instancia.SumarCorzuela(5); // Sube el nativo, baja el axis
            }
            Destroy(collision.gameObject); 
            Destroy(gameObject);           
        }

        // SI LE PEGA A UN CORZUELA (Nativo) -> MUY MALO
        if (collision.CompareTag("Corzuela"))
        {
            if (GameManager.instancia != null)
            {
                GameManager.instancia.RestarCorzuela(20); // Penalización grave (-20)
            }
            Destroy(collision.gameObject); 
            Destroy(gameObject);           
        }
    }
}