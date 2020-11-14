using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
    public float jumpSpeed;
    public LayerMask ground;
    public float mileStone, speedMultiplier;
    private float mileStoneCount;
    public AudioSource jumpSound, deathSound;

    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    private Animator animator;

    public LayerMask gameOverGround;
    public GameManager gameManager;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        mileStoneCount = mileStone;
    }

    void Update()
    {
        bool isGameOver = Physics2D.IsTouchingLayers(playerCollider, gameOverGround);
        if (isGameOver) {
            gameOver();
        }
        if (transform.position.x > mileStoneCount) {
            mileStoneCount += mileStone;
            speed = speed * speedMultiplier;
            mileStone += mileStone * speedMultiplier;
        }
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        bool isPlayerGrounded = Physics2D.IsTouchingLayers(playerCollider, ground);
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isPlayerGrounded) {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            jumpSound.Play();
        }

        animator.SetBool("isGrounded",isPlayerGrounded);
    }

    void gameOver() {
        gameManager.gameOver();
        
    }
}
