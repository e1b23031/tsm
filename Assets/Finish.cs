using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // �Q�[���ăX�^�[�g�i��FMainScene �ɖ߂�j
    public void RetryGame()
    {
        SceneManager.LoadScene("SampleScene"); // �� ���Ȃ��̃Q�[���V�[�����ɕύX
    }

    // �A�v���I��
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^�ł��~�܂�悤��
#endif
    }
}

