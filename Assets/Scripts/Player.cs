using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData playerData;
    public static int currentLife{get; private set;}
    private float currentSpeed;

    [Header("Component References")]
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start() {
        currentLife = playerData.life;
    }

    void Update()
    {
        // Animation parameters
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetBool("walking", inputVector.magnitude > 0);
        spriteRenderer.flipX = inputVector.x != 0 && inputVector.x < 0;
    }

    void FixedUpdate()
    {
        // Applying velocity
        rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerData.speed, Input.GetAxisRaw("Vertical") * playerData.speed);
    }

    public static void ApplyDamage(int damage) {
        currentLife -= damage;
    }

    public void SetBuff(float buff) {
        currentSpeed = playerData.speed + buff;
    }
}
