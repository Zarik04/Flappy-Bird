using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;//control the speed
    private int score = 0;
    public Text scoreText;
    private Rigidbody2D rb;
    public bool isDead = false;

    public SpriteRenderer spriteRenderer;  // Reference to the bird's SpriteRenderer
    public Sprite[] birdSprites;           // Array to hold 3 bird sprites
    public float animationSpeed = 0.1f;    // Speed of the animation (how fast to switch sprites)

    private bool isAnimating = false;      // To check if the bird is animating

    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public AudioClip scoreSound;
    void Start()
    {
        //get rigibody2d Component of the BirdbBek
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetMouseButtonDown(0) --> left side mouse button pressed down
        if(Input.GetMouseButtonDown(0) && isDead==false && !isAnimating){
            rb.velocity = Vector2.up * speed;
            SoundManager.instance.PlaySound (jumpSound);
            StartCoroutine(PlayFlapAnimation());
        }
    }

    // Coroutine to play the flapping animation
    IEnumerator PlayFlapAnimation()
    {
        isAnimating = true;  // Set the animating flag to true
        for (int i = 0; i < birdSprites.Length; i++)
        {
            spriteRenderer.sprite = birdSprites[i];  // Switch to the next sprite
            yield return new WaitForSeconds(animationSpeed);  // Wait for a short duration
        }
        isAnimating = false;  // Set animating flag to false when animation ends
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        SoundManager.instance.PlaySound (gameOverSound);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        scoreText.text = score.ToString();
        SoundManager.instance.PlaySound (scoreSound);
    }

}