using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // �� �VInput System���g���Ă���ꍇ

public class StartUI : MonoBehaviour
{
    void Update()
    {
        // Enter�L�[�iReturn�L�[�j�ŃQ�[���J�n
        if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Main"); // �� �Q�[���{�҂̃V�[�����ɕύX
        }
    }
}


