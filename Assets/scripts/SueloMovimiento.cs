using UnityEngine;

public class SueloMovimiento : MonoBehaviour
{
    public float velocidad = 7f;

    void Update()
    {
        // El suelo se mueve a la izquierda
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);

        // Si el suelo se va de la pantalla, lo reposicionamos adelante (Loop)
        if (transform.position.x < -20f)
        {
            transform.position = new Vector3(20f, transform.position.y, transform.position.z);
        }
    }
}


