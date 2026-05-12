using UnityEngine;
using System.Collections.Generic;

public class CarruselSuelo : MonoBehaviour
{
    public float velocidad = 5f;
    public float anchoPieza = 1.28f;
    public Sprite[] misDibujos;
    
    // Esta variable controla si el suelo se mueve o no
    public bool juegoEmpezo = false; 

    private List<Transform> piezas = new List<Transform>();

    void Start()
    {
        foreach (Transform hijo in transform)
        {
            piezas.Add(hijo);
        }
        piezas.Sort((a, b) => a.localPosition.x.CompareTo(b.localPosition.x));
    }

    void Update()
    {
        // 1. Detectar si el jugador toca una tecla (ej: Espacio) para arrancar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            juegoEmpezo = true;
        }

        // 2. Solo se mueve si juegoEmpezo es true
        if (juegoEmpezo)
        {
            MoverSuelo();
        }
    }

    void MoverSuelo()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);

        if (piezas[0].position.x < -25f) 
        {
            ReposicionarPieza();
        }
    }

void ReposicionarPieza()
{
    Transform piezaASaltar = piezas[0];
    piezas.RemoveAt(0);

    // En lugar de basarnos en la posición de la última, 
    // calculamos la posición teórica que DEBERÍA tener.
    // Esto evita que los huecos se sumen.
    float nuevaXLocal = piezas[piezas.Count - 1].localPosition.x + anchoPieza;
    
    piezaASaltar.localPosition = new Vector3(nuevaXLocal, piezaASaltar.localPosition.y, piezaASaltar.localPosition.z);

    if (misDibujos.Length > 0)
        piezaASaltar.GetComponent<SpriteRenderer>().sprite = misDibujos[Random.Range(0, misDibujos.Length)];

    piezas.Add(piezaASaltar);
}
}