using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Otros métodos y configuraciones del menú principal...

    public void OnExitButtonPressed()
    {
        // Salir del juego
        Application.Quit();

        // Esto solo se ejecutará en el Editor de Unity para simular la salida del juego
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnStartGameButtonPressed()
    {
        // Iniciar el juego, puedes cargar la primera escena del juego aquí
        SceneManager.LoadScene("Level_1");
    }
}