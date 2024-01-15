using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicPlayer : MonoBehaviour
{
    private AudioManager audioManager;

    void Start()
    {
        // Buscar el objeto AudioManager en la escena
        audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null)
        {
            // Reproducir la m�sica de fondo al inicio del juego
            audioManager.PlayBackgroundMusic();
        }
        else
        {
            Debug.LogError("No se encontr� un objeto AudioManager en la escena.");
        }
    }
}
