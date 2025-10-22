using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    private int currentScore = 0;
    public TextMeshProUGUI scoreText; // ��������ύX�I

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreText();

        if (scoreText != null)
        {
            scoreText.color = Color.blue;
        }
    }

    public void AddScore(int value)
    {
        currentScore += value;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}
