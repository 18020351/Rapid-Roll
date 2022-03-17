using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;
    public Text textScore;
    public Text textLives;
    public Text textGameOver;
    public int score = 0;
    public int lives = 5;
    private void Awake()
    {
        instanceGameManager = this;
    }
    public void Die()
    {
        lives--;
    }
    public void AddLives()
    {
        lives++;
    }
    private void Update()
    {
        textLives.text = "Lives: " + lives;
        textScore.text = "Score: " + score;
        if (lives == 0)
        {
            GameOver();
        }
    }
    public void CallBackDie(IEnumerator action)
    {
        if (lives > 0)
        {
            StartCoroutine(action);
        }

    }
    public void GameOver()
    {
        textGameOver.gameObject.SetActive(true);
    }
    public void Restart()
    {
        lives = 5;
    }

}
