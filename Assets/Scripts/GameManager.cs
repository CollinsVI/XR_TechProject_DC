using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;        
    public Text scoreText;        
    public GameObject gameOverUI; 

    private int score = 0;        
    private float gameDuration = 60f; 
    private bool isGameOver = false;

    void Start()
    {
        gameOverUI.SetActive(false);
        UpdateScoreText();
    }

    void Update()
    {
        if (isGameOver) return;

        // Update the timer
        gameDuration -= Time.deltaTime;

        if (gameDuration <= 0)
        {
            EndGame();
        }
        else
        {
            timerText.text = $"Time: {Mathf.CeilToInt(gameDuration)}";
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    private void EndGame()
    {
        isGameOver = true;
        timerText.text = "Time: 0";
        gameOverUI.SetActive(true);
        gameOverUI.GetComponentInChildren<Text>().text = $"Game Over!\nYour Score: {score}";
    }
}
