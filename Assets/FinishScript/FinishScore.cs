using UnityEngine;
using TMPro;  // TextMeshProを使う

public class FinishScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UIに表示するTextMeshProの参照

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0); // スコアを取得（0はデフォルト値）

        // UIにスコアを表示
        if (scoreText != null)
        {
            scoreText.text = "Score: " + finalScore.ToString();
        }
    }
}
