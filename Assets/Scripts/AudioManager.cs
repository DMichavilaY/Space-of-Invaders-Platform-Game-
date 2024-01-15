using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Asigna la música en el Inspector
    public AudioClip victoryMusic; // Nueva: Asigna la música de victoria en el Inspector
    private AudioSource musicSource;
    internal static object instance;

    private void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();

        // Configuración adicional del AudioSource para la música
        musicSource.loop = true; // Repetir la música continuamente
        musicSource.playOnAwake = false; // Desactivar la reproducción automática al inicio

        // Reproducir la música al inicio del juego
        PlayBackgroundMusic();
    }

    // Función para reproducir la música de fondo
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    // Función para reproducir la música de victoria
    public void PlayVictoryMusic()
    {
        // Detener la música de fondo actual
        musicSource.Stop();

        // Reproducir la música de victoria
        if (victoryMusic != null)
        {
            musicSource.clip = victoryMusic;
            musicSource.Play();
        }
    }

    // Resto del código del AudioManager...
}

