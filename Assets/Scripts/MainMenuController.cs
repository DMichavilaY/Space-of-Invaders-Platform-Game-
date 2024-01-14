using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;

    private void Start()
    {
        // Asociar la funci�n OnStartButtonClick al evento de clic del bot�n
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        // Cargar la escena del nivel 1
        SceneManager.LoadScene("Level_1");
    }
}
