using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    public float jumpForce = 5;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public string nextSceneName = "NombreDeTuNuevaEscena";
    public SpriteRenderer pauseSpriteRenderer;
    public KeyCode pauseKey = KeyCode.P;

    public AudioClip jumpSound;
    public AudioClip victoryMusic; // Nuevo: Asigna la música de victoria en el Inspector
    private AudioSource audioSource;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool wasGrounded = true;

    private int collectiblesCollected = 0;
    public int collectiblesGoal = 4;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.freezeRotation = true;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePause();
        }

        if (collectiblesCollected < collectiblesGoal)
        {
            // Solo permitir el control del personaje si no se han recolectado todos los coleccionables
            HandleCharacterControl();
        }
    }

    void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            // Si el juego está pausado, reanuda el tiempo y desactiva el SpriteRenderer
            Time.timeScale = 1f;
            pauseSpriteRenderer.enabled = false;
        }
        else
        {
            // Si el juego no está pausado, pausa el tiempo y activa el SpriteRenderer
            Time.timeScale = 0f;
            pauseSpriteRenderer.enabled = true;
        }
    }

    void HandleCharacterControl()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * horizontalMovement, rb.velocity.y);
        animator.SetBool("Move", horizontalMovement != 0);

        if (horizontalMovement > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("Jump", true);

            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }

            isGrounded = false;
        }

        if (isGrounded && !wasGrounded)
        {
            animator.SetBool("Jump", false);
        }

        wasGrounded = isGrounded;

        if (isGrounded && !Input.GetButton("Jump"))
        {
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            collectiblesCollected++;

            if (collectiblesCollected >= collectiblesGoal)
            {
                StartCoroutine(PlayVictoryMusicAndEndGame());
            }

            other.gameObject.SetActive(false);
        }
    }

    // Nueva: Corrutina para reproducir la música de victoria y terminar el juego después de 2 segundos
    private IEnumerator PlayVictoryMusicAndEndGame()
    {
        // Reproducir la música de victoria
        if (victoryMusic != null)
        {
            audioSource.clip = victoryMusic;
            audioSource.Play();
        }

        // Esperar 2 segundos
        yield return new WaitForSeconds(2f);

        // Terminar el juego
        EndGame();
    }

    /// Nueva: Función para terminar el juego
    private void EndGame()
    {
        Debug.Log("¡Has recolectado todos los coleccionables! Juego terminado.");

        // Cargar la nueva escena definida en nextSceneName
        SceneManager.LoadScene(nextSceneName);
    }
}
