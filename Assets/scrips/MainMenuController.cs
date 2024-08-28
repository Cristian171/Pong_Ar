using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game"); // Aseg�rate de que "Game" es el nombre correcto de la escena
    }

    public void QuitGame()
    {
        // Salir del juego o cerrar la aplicaci�n
        Application.Quit();
    }
}

