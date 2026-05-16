using UnityEngine;
using UnityEngine.UI;

public class ControladorEcobalanza : MonoBehaviour
{
    [Header("Imágenes de Relleno")]
    public Image imagenRellenoCorzuela; 
    public Image imagenRellenoAxis;     
    
    private float puntosCorzuela;
    private float puntosAxis;
    private bool juegoTerminado = false;

    void Start()
    {
        // Ambos arrancan exactamente a la mitad (50% de 100)
        puntosCorzuela = 50f; 
        puntosAxis = 50f;     
        
        ActualizarBarras();
    }

    // Se ejecuta cuando impactás a un Axis (Acierto)
    public void ImpactoAxis(float cantidad)
    {
        if (juegoTerminado) return;

        // El Axis baja y la Corzuela sube
        puntosAxis = Mathf.Clamp(puntosAxis - cantidad, 0f, 100f);
        puntosCorzuela = Mathf.Clamp(puntosCorzuela + cantidad, 0f, 100f);
        
        ActualizarBarras();
        ChequearVictoria();
    }

    // Se ejecuta cuando te equivocás y le pegás a una Corzuela (Castigo doble)
    public void ImpactoCorzuela(float cantidad)
    {
        if (juegoTerminado) return;

        // La Corzuela baja el doble y el Axis sube el doble
        puntosCorzuela = Mathf.Clamp(puntosCorzuela - (cantidad * 2f), 0f, 100f);
        puntosAxis = Mathf.Clamp(puntosAxis + (cantidad * 2f), 0f, 100f);
        
        ActualizarBarras();
        ChequearVictoria();
    }

    void ActualizarBarras()
    {
        // Dividimos por 100f para pasar el valor al rango de 0 a 1 que usa el Image Filled
        imagenRellenoCorzuela.fillAmount = puntosCorzuela / 100f;
        imagenRellenoAxis.fillAmount = puntosAxis / 100f;
    }

    void ChequearVictoria()
    {
        // Condición de victoria: Corzuela al máximo (100) y Axis erradicado (0)
        if (puntosCorzuela >= 100f && puntosAxis <= 0f)
        {
            juegoTerminado = true;
            Debug.Log("¡GANASTE! El bioma está equilibrado. Corzuela: 100% | Axis: 0%");
            // Acá más adelante podés activar tu pantalla de victoria
        }
    }
}