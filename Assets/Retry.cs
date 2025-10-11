using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // ゲーム再スタート（例：MainScene に戻る）
    public void RetryGame()
    {
        SceneManager.LoadScene("SampleScene"); // ← あなたのゲームシーン名に変更
    }
}

