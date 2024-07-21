using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallControl : MonoBehaviour
{
    private bool reached, side = true; // side true is AI, false is player
    private float speed = 5.0f;
    public Vector3 newPosition = new(0, 4, 0);
    private TMP_Text playerScoreText, botScoreText;
    
    void Start()
    {
        playerScoreText = GameObject.FindWithTag("PlayerScore").GetComponent<TMP_Text>();
        botScoreText = GameObject.FindWithTag("BotScore").GetComponent<TMP_Text>();
    }
    void ChangeScore(TMP_Text text, int score)
    {
        text.text = (++score).ToString();
        reached = true;
        side = true;
        transform.position = Vector3.zero;
        speed = 5.0f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
        audio.Play();

        int playerScore = int.Parse(playerScoreText.text);
        int botScore = int.Parse(botScoreText.text);
        if (collision.CompareTag("Player Goal"))
        {
            ChangeScore(botScoreText, botScore);
        }
        else if (collision.CompareTag("AI Goal"))
        {
            ChangeScore(playerScoreText, playerScore);
        }
        else if (collision.CompareTag("Player") || collision.CompareTag("AI"))
        {
            reached = true;
            speed += 0.3f;
        }
    }

    public void NewPos(int y)
    {
        newPosition = new Vector3(Random.Range(-8, 8), y, 0);
        side = !side;
        reached = false;
    }
    void Update()
    {
        if (reached)
        {
            if (side == true)
                NewPos(4);
            else
                NewPos(-4);
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed);
            if (transform.position == newPosition)
                reached = true;
            
        }
    }
}
