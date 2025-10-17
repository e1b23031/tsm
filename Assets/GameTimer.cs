using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro用

public class GameTimer : MonoBehaviour
{
    [Header("ゲーム制限時間")]
    public float gameDuration = 10f; // 制限時間（秒）

    [Header("UI参照")]
    public TextMeshProUGUI timerText; // 残り時間を表示するText

    private float endTime; // 終了時刻

    void Start()
    {
        endTime = Time.time + gameDuration;
    }

    void Update()
    {
        float remaining = Mathf.Max(0f, endTime - Time.time); // 残り秒数
        int minutes = Mathf.FloorToInt(remaining / 60f);      // 分
        int seconds = Mathf.FloorToInt(remaining % 60f);      // 秒

        // 〇.〇の形式で表示
        if (timerText != null)
        {
            timerText.text = $"{minutes}.{seconds:D2}";
            if (remaining <= 30f)
                timerText.color = Color.red;
            else
                timerText.color = Color.black;

        }

        // 時間切れでゲームオーバーへ
        if (remaining <= 0f)
        {
            SceneManager.LoadScene("Finish");
        }
    }
}

