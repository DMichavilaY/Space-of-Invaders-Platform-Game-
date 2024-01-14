using System.Collections;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        if (collectSound != null)
        {
            audioSource.PlayOneShot(collectSound);
        }

        // Desactivar el GameObject del coleccionable
        gameObject.SetActive(false);

        // Registrar el número de coleccionables recolectados en algún lugar oculto
        GameManager.instance.IncrementCollectibles();
    }
}
