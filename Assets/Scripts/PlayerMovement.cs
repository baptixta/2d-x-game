using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;

    [Header("Component References")]
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    void Update()
    {
        // Animation parameters
        animator.SetBool("walking", Input.GetAxisRaw("Horizontal") != 0);
        spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Horizontal") < 0;
    }

    void FixedUpdate()
    {
        // Applying velocity
        rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
    }
}
