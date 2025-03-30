using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int lives = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public PlayerController player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateUI();
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
            Destroy(player.gameObject);
        }
        else
        {
            player.ResetPosition();
        }
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }
}
