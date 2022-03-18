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
    public Button btnRestart;
    [SerializeField]
    private PlayController _player;
    public int score = 0;
    public int lives = 5;
    public bool isCheck;

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
        btnRestart.gameObject.SetActive(true);
        isCheck = false;
    }
    public void Restart()
    {
        lives = 5;
        score = 0;
        isCheck = true;
        textGameOver.gameObject.SetActive(false);
        btnRestart.gameObject.SetActive(false);
        _player.ReSpawn();
    }
    public void addSocre(Rigidbody2D rb)
    {
        float speed = -rb.velocity.y;
        score += (int)speed;
    }
}
