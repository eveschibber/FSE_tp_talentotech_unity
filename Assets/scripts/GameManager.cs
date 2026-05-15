using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // <-- IMPORTANTE: Librería para manejar TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [Header("Poblaciones (Total 100)")]
    public int poblacionCorzuela = 50; 
    public int poblacionAxis = 50;     

    [Header("Componentes de UI")]
    public TextMeshProUGUI textoCorzuela; // El componente de texto para el nativo
    public TextMeshProUGUI textoAxis;     // El componente de texto para el exótico

    void Awake()
    {
        if (instancia == null) { instancia = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        // Actualizamos la pantalla apenas arranca el juego
        ActualizarInterfaz();
    }

    public void SumarCorzuela(int cantidad)
    {
        poblacionCorzuela += cantidad;
        poblacionAxis -= cantidad; 

        poblacionCorzuela = Mathf.Clamp(poblacionCorzuela, 0, 100);
        poblacionAxis = Mathf.Clamp(poblacionAxis, 0, 100);

        ActualizarInterfaz();
        VerificarCondicionesVictoria();
    }

    public void RestarCorzuela(int cantidad)
    {
        poblacionCorzuela -= cantidad;
        poblacionAxis += cantidad; 

        poblacionCorzuela = Mathf.Clamp(poblacionCorzuela, 0, 100);
        poblacionAxis = Mathf.Clamp(poblacionAxis, 0, 100);

        ActualizarInterfaz();
        VerificarCondicionesVictoria();
    }

    // NUEVA FUNCIÓN: Modifica lo que el jugador ve en la pantalla
    void ActualizarInterfaz()
    {
        if (textoCorzuela != null)
        {
            textoCorzuela.text = "Corzuelas (Nativo): " + poblacionCorzuela + "%";
        }
        
        if (textoAxis != null)
        {
            textoAxis.text = "Ciervo Axis (Invasor): " + poblacionAxis + "%";
        }
    }

    void VerificarCondicionesVictoria()
    {
        if (poblacionCorzuela >= 100 && poblacionAxis <= 0)
        {
            Debug.Log("¡GANASTE! Restauraste el ecosistema.");
        }
        else if (poblacionCorzuela <= 0)
        {
            Debug.Log("GAME OVER: El ciervo Axis extinguió a la Corzuela.");
            ReiniciarNivel();
        }
    }

    void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}