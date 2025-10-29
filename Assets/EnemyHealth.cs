using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyHealth : MonoBehaviour
{
    [Header("HP / Score")]
    public int maxHP = 3;        // �f�t�H���g�BSpawner����㏑�������
    public int scoreOnKill = 10;

    [Header("Sound Effect")]
    public AudioClip hitSound;  // �_���[�W�E���S���̓�����
    private AudioSource audioSource;

    int currentHP = 0;
    bool isDead = false;

    void Awake()
    {
        if (currentHP <= 0) currentHP = maxHP;

        var col = GetComponent<Collider>();
        col.isTrigger = true; // �e��OnTriggerEnter�œ��Ă�z��
        gameObject.tag = "Enemy";

        audioSource = GetComponent<AudioSource>();  // AudioSource�̎擾
    }

    // �X�|�[�����ɏ����������
    public void Initialize(int hp, int score)
    {
        maxHP = hp;
        scoreOnKill = score;
        currentHP = hp;
        isDead = false;
    }

    public void TakeDamage(int dmg)
    {
        if (isDead) return;

        currentHP -= dmg;

        // ���������_���[�W�������S�����Đ�
        PlaySound(hitSound);  // �_���[�W���i���S���ɂ��g�p�j

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // isDead �����ł� true �Ȃ�A�����𒆒f
        if (isDead) return;
        isDead = true;

        // ���S�����Đ��i�_���[�W���Ɠ������j
        PlaySound(hitSound);  // ���S�������������g�p

        // �X�R�A���Z����
        if (Score.instance != null)
        {
            Score.instance.AddScore(scoreOnKill);
        }

        // �I�u�W�F�N�g���폜
        Destroy(gameObject);
    }

    // �����Đ����郁�\�b�h�𓝈�
    private void PlaySound(AudioClip sound)
    {
        if (sound != null && audioSource && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(sound);  // �����Đ�
        }
    }
}
