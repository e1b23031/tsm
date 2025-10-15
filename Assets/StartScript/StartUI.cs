using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    // スタートボタンを押したとき
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    // 終了ボタンを押したとき
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

