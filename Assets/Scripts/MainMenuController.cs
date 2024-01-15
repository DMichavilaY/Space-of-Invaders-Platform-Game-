using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Otros m�todos y configuraciones del men� principal...

    public void OnExitButtonPressed()
    {
        // Salir del juego
        Application.Quit();

        // Esto solo se ejecutar� en el Editor de Unity para simular la salida del juego
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnStartGameButtonPressed()
    {
        // Iniciar el juego, puedes cargar la primera escena del juego aqu�
        SceneManager.LoadScene("Level_1");
    }
}