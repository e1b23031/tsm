using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // �Q�[���ăX�^�[�g�i��FMainScene �ɖ߂�j
    public void RetryGame()
    {
        SceneManager.LoadScene("SampleScene"); // �� ���Ȃ��̃Q�[���V�[�����ɕύX
    }
}

