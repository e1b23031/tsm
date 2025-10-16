using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishUI : MonoBehaviour
{
    // ゲーム再スタート（例：MainScene に戻る）
    public void RetryGame()
    {
        SceneManager.LoadScene("Start"); 
    }

    // アプリ終了
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタでも止まるように
#endif
    }
}

