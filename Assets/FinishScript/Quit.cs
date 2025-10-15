using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    // アプリ終了
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタでも止まるように
#endif
    }
}

