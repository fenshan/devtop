using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerFlappy : MonoBehaviour
{
    public static ManagerFlappy instance = null;

    public bool gameOver;
    public GameObject GameOverSprite;
    public GameObject WinSprite;

    public Text ScoreText;
    public float Score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    public void Start()
    {
        GameOverSprite.SetActive(false);
        WinSprite.SetActive(false);
    }

    public void Update()
    {
        if (!gameOver)
        {
            Score = Score + Time.deltaTime;
            ScoreText.text = "Score: " + Mathf.Floor(Score * 100);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            Restart();
        }
    }

    public void Lose()
    {
        gameOver = true;

        if (Mathf.Floor(Score * 100) < 3000)
        {
            GameOverSprite.SetActive(true);
        }
        else
        {
            WinSprite.SetActive(true);
            PlayerPrefs.SetInt("key1", 1);
        }
    }

    public void Restart()
    {
        gameOver = false;
        FindObjectOfType<FlipFlopMovement>().ResetPosition();
        GameOverSprite.SetActive(false);
        Score = 0;
    }
}
