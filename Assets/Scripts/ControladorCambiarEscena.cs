using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCambiarEscena : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void CambiarEscena(string nombre)
    {
        print("Cambiando a la escena: " + nombre + ".");
        SceneManager.LoadScene(nombre);
    }
}
