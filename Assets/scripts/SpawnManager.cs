using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs de los Ciervos")]
    public GameObject axisPrefab;       
    public GameObject corzuelaPrefab;   

    [Header("Configuración de Distancia (Ajustable)")]
    // Estas casillas van a aparecer en el Inspector para que las muevas a gusto
    public float distanciaX = 1500f; 
    public float rangoY = 3f;        

    [Header("Configuración de Tiempo")]
    public float tiempoEntreSpawns = 3f;

    void Start()
    {
        InvokeRepeating("SpawnearAnimal", 2f, tiempoEntreSpawns);
    }

    void SpawnearAnimal()
    {
        // Conseguimos la posición de la cámara
        float cameraX = Camera.main.transform.position.x;
        float cameraY = Camera.main.transform.position.y;

        // Usamos las variables del Inspector en la fórmula
        // Sumamos la distanciaX al eje X de la cámara
        // Y hacemos el rango aleatorio usando el valor de rangoY (positivo y negativo)
        Vector3 posicionSpawn = new Vector3(
            cameraX + distanciaX, 
            cameraY + Random.Range(-rangoY, rangoY), 
            0f
        );

        int bichoAleatorio = Random.Range(0, 2);

        if (bichoAleatorio == 0)
        {
            Instantiate(axisPrefab, posicionSpawn, Quaternion.identity);
        }
        else
        {
            Instantiate(corzuelaPrefab, posicionSpawn, Quaternion.identity);
        }
    }
}