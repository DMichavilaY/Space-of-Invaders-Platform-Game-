using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 2;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderder;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderder = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        animator.SetBool("Move", Input.GetAxisRaw("Horizontal") != 0);

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderder.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderder.flipX = true;
        }
    }
}
