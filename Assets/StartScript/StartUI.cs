using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // ← 新Input Systemを使っている場合

public class StartUI : MonoBehaviour
{
    void Update()
    {
        // Enterキー（Returnキー）でゲーム開始
        if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Main"); // ← ゲーム本編のシーン名に変更
        }
    }
}


