using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EXAMPLE_MVMNTCNTRLR : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject GameOverScreen;

    private int score;

    public float JumpSpeed = 1;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
        score = 0;
        scoreText.text = score.ToString();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    
    void Jump()
    {
        rb.velocity = new Vector2(0, JumpSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Hazard"))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    void GameOver()
    {
        GameOverScreen.SetActive(true);
        Debug.Log("GAME OVER! Score: " + score);
        Time.timeScale = 0;
    }
}
