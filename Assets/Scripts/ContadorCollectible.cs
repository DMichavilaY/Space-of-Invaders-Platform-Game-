using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ContadorCollectible : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public int requiredCollectibles = 4;
    public string nextLevelName = "NombreDeTuNivel2";
    public AudioClip victoryMusic;  // Agrega aquí la música de victoria

    private int collectedCollectibles = 0;

    private void Start()
    {
        UpdateCountText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            collectedCollectibles++;

            UpdateCountText();

            // Verificar si se han recolectado todos los coleccionables
            if (collectedCollectibles >= requiredCollectibles)
            {
                StartCoroutine(PlayVictoryMusicAndChangeLevel());
            }
        }
    }

    private void UpdateCountText()
    {
        countText.text = collectedCollectibles + "/" + requiredCollectibles;
    }

    IEnumerator PlayVictoryMusicAndChangeLevel()
    {
        // Reproducir la música de victoria utilizando el componente AudioSource en este objeto
        if (victoryMusic != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                // Si no hay un AudioSource, agregamos uno
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            audioSource.clip = victoryMusic;
            audioSource.Play();
        }

        // Esperar 2 segundos antes de cambiar de nivel
        yield return new WaitForSeconds(2f);

        // Cambiar a la siguiente escena/nivel
        SceneManager.LoadScene(nextLevelName);
    }
}
