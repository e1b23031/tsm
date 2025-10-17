using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro�p

public class GameTimer : MonoBehaviour
{
    [Header("�Q�[����������")]
    public float gameDuration = 10f; // �������ԁi�b�j

    [Header("UI�Q��")]
    public TextMeshProUGUI timerText; // �c�莞�Ԃ�\������Text

    private float endTime; // �I������

    void Start()
    {
        endTime = Time.time + gameDuration;
    }

    void Update()
    {
        float remaining = Mathf.Max(0f, endTime - Time.time); // �c��b��
        int minutes = Mathf.FloorToInt(remaining / 60f);      // ��
        int seconds = Mathf.FloorToInt(remaining % 60f);      // �b

        // �Z.�Z�̌`���ŕ\��
        if (timerText != null)
        {
            timerText.text = $"{minutes}.{seconds:D2}";
            if (remaining <= 30f)
                timerText.color = Color.red;
            else
                timerText.color = Color.black;

        }

        // ���Ԑ؂�ŃQ�[���I�[�o�[��
        if (remaining <= 0f)
        {
            SceneManager.LoadScene("Finish");
        }
    }
}

