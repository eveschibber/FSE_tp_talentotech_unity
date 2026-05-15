using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ciervoPrefab;
    public float tiempoInicio = 2f;
    public float intervalo = 3f;
    
    // NUEVA VARIABLE VISIBLE EN EL EDITOR
    public float alturaSueloY = 120f; 

    private bool juegoEmpezado = false;

    void Update()
    {
        if (!juegoEmpezado && Input.GetKeyDown(KeyCode.Space))
        {
            juegoEmpezado = true;
            InvokeRepeating("GenerarCiervo", tiempoInicio, intervalo);
        }
    }

    void GenerarCiervo()
    {
        // USAMOS LA NUEVA VARIABLE PARA LA ALTURA
        Vector3 posicionSpawn = new Vector3(1500, alturaSueloY, 0); 
        Instantiate(ciervoPrefab, posicionSpawn, Quaternion.identity);
    }
}