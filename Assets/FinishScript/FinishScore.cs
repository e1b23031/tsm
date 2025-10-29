using UnityEngine;
using TMPro;  // TextMeshPro���g��

public class FinishScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI�ɕ\������TextMeshPro�̎Q��

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0); // �X�R�A���擾�i0�̓f�t�H���g�l�j

        // UI�ɃX�R�A��\��
        if (scoreText != null)
        {
            scoreText.text = "Score: " + finalScore.ToString();
        }
    }
}
