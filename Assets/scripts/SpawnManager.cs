using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs de los Ciervos")]
    public GameObject axisPrefab;       
    public GameObject corzuelaPrefab;   

    [Header("Configuración de Distancia (Ajustable)")]
    // Estas casillas van a aparecer en el Inspector para que las muevas a gusto
    public float distanciaX = 1500f; 
    public float rangoY = 130f;        

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

        // EL CAMBIO ACÁ:
        // En el eje X usamos la distancia ajustable.
        // En el eje Y usamos el valor de rangoY DIRECTO (sin el Random.Range) para que sea una altura fija.
        Vector3 posicionSpawn = new Vector3(
            cameraX + distanciaX, 
            rangoY, // Ya no es aleatorio, ahora es la altura fija del piso
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