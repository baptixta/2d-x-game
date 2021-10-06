using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData playerData;
    public static int currentLife{get; private set;}
    private float currentSpeed;
    public static bool playerControlsEnabled = true;
    public static bool isDashing = false;

    [Header("Component References")]
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] GameObject levelTransition;

    private void Start() {
        currentLife = playerData.life;
    }

    void Update()
    {
        // Animation parameters
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetBool("walking", inputVector.magnitude > 0);
        spriteRenderer.flipX = inputVector.x != 0 && inputVector.x < 0; 

        if (isDashing) 
        {
            rigidbody.AddForce(transform.up * playerData.dashSpeed);
        } 
    }

    void FixedUpdate()
    {
        if (playerControlsEnabled && isDashing == false) 
        {
            // Applying velocity
            rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerData.speed, Input.GetAxisRaw("Vertical") * playerData.speed);            
        }
        else 
        {
             StartCoroutine(StopMoving());        
        }        
    }

    IEnumerator StopMoving() 
    {
        rigidbody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(3f);        
    }   

    public static void ApplyDamage(int damage) {
        currentLife -= damage;
    }

    public void SetBuff(float buff) {
        currentSpeed = playerData.speed + buff;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        // Collider da fase 1 no lobby
        if (other.tag == "Level01") {
            animator.SetBool("disappear", true);            
            levelTransition.SetActive(true);  
            playerControlsEnabled = false;
            StartCoroutine(GotoLevel());          
        }

        // Collider do Dash
        if (other.tag == "dash")
        {            
            Dash();
            other.gameObject.GetComponent<Animator>().SetTrigger("dash");
        }
    }

    // Dash do Player
    public void Dash() 
    {
        isDashing = true;        
        StartCoroutine(StopDash());
    }

    IEnumerator StopDash() {
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
    }

    IEnumerator GotoLevel() {
        yield return new WaitForSeconds(1.5f);
        playerControlsEnabled = true;
        SceneManager.LoadScene("Level01");        
    }
}
