using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 15f;
    public float puntosImpacto = 10f; // El valor base que se va a mover (ej: 10%)

    void Update()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otroObjeto)
    {
        ControladorEcobalanza ecobalanza = FindObjectOfType<ControladorEcobalanza>();
        if (ecobalanza == null) return;

        if (otroObjeto.CompareTag("Axis"))
        {
            // Avisamos que le pegamos a un Axis
            ecobalanza.ImpactoAxis(puntosImpacto);
            
            Destroy(otroObjeto.gameObject);
            Destroy(gameObject); 
        }
        else if (otroObjeto.CompareTag("Corzuela"))
        {
            // Avisamos que nos equivocamos y le pegamos a una Corzuela
            ecobalanza.ImpactoCorzuela(puntosImpacto);
            
            Destroy(otroObjeto.gameObject); // Opcional: quitás la corzuela por el error
            Destroy(gameObject);
        }
    }
}