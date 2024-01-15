using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Asigna la m�sica en el Inspector
    public AudioClip victoryMusic; // Nueva: Asigna la m�sica de victoria en el Inspector
    private AudioSource musicSource;
    internal static object instance;

    private void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();

        // Configuraci�n adicional del AudioSource para la m�sica
        musicSource.loop = true; // Repetir la m�sica continuamente
        musicSource.playOnAwake = false; // Desactivar la reproducci�n autom�tica al inicio

        // Reproducir la m�sica al inicio del juego
        PlayBackgroundMusic();
    }

    // Funci�n para reproducir la m�sica de fondo
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    // Funci�n para reproducir la m�sica de victoria
    public void PlayVictoryMusic()
    {
        // Detener la m�sica de fondo actual
        musicSource.Stop();

        // Reproducir la m�sica de victoria
        if (victoryMusic != null)
        {
            musicSource.clip = victoryMusic;
            musicSource.Play();
        }
    }

    // Resto del c�digo del AudioManager...
}

