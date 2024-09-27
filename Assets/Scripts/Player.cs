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
        if(Input.GetMouseButtonDown(0) && isDead==false){
            rb.velocity = Vector2.up * speed;
            SoundManager.instance.PlaySound (jumpSound);
        }
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