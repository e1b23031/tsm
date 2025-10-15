using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    // �X�^�[�g�{�^�����������Ƃ�
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    // �I���{�^�����������Ƃ�
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

