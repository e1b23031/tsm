using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    // �A�v���I��
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^�ł��~�܂�悤��
#endif
    }
}

