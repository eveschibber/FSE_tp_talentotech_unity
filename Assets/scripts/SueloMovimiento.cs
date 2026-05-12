using UnityEngine;

public class SueloMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float anchoPieza = 2.56f; // El ancho de UN solo bloquecito
    public int cantidadBloques = 10; // Cuántos bloques tenés en fila
    
    public Sprite[] misDibujosDeSuelo; // Arrastrá acá todos tus sprites de fósiles, libros, etc.
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Mover a la izquierda
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);

        // Si este bloque sale de pantalla
        if (transform.position.x <= -anchoPieza)
        {
            // Lo movemos al final de la fila de bloques
            float nuevaX = transform.position.x + (anchoPieza * cantidadBloques);
            transform.position = new Vector3(nuevaX, transform.position.y, transform.position.z);

            // ¡Acá está la magia! Cambiamos el dibujo al azar
            int indiceAzar = Random.Range(0, misDibujosDeSuelo.Length);
            sr.sprite = misDibujosDeSuelo[indiceAzar];
        }
    }
}