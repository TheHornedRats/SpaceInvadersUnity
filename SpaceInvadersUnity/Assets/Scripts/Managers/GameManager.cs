using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int lives = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public PlayerController player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateUI();
        gameOverText.gameObject.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void TakeLife()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            EndGame();
        }
        else
        {
            player.ResetPosition();
        }
    }

    public void ForceGameOver()
    {
        lives = 0;
        UpdateUI();
        EndGame();
    }

    private void EndGame()
    {
        if (player != null)
        {
            Destroy(player.gameObject);
        }

        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }
}
