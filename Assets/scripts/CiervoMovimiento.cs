using UnityEngine;

public class CiervoMovimiento : MonoBehaviour
{
    public float velocidad = 7f;

    void Update()
    {
        // "Space.World" hace que el ciervo ignore su propia rotación 
        // y se mueva hacia la izquierda absoluta de la pantalla.
        transform.Translate(Vector3.left * velocidad * Time.deltaTime, Space.World);

        // Si se va muy a la izquierda, desaparece
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}