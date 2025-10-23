using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyHealth : MonoBehaviour
{
    [Header("HP / Score")]
    public int maxHP = 3;        // �f�t�H���g�BSpawner����㏑�������
    public int scoreOnKill = 10;

    [Header("Sound Effects")]
    public AudioClip damageSound;  // �_���[�W���̉�
    public AudioClip deathSound;   // ���S���̉�
    private AudioSource audioSource;

    [Header("Effects")]
    public GameObject damageEffect;  // �_���[�W���̃G�t�F�N�g
    public GameObject deathEffect;   // ���S���̃G�t�F�N�g

    int currentHP = 0;
    bool isDead = false;

    void Awake()
    {
        // Spawner����Initialize����Ȃ������ꍇ�̕ی�
        if (currentHP <= 0) currentHP = maxHP;

        var col = GetComponent<Collider>();
        col.isTrigger = true; // �e��OnTriggerEnter�œ��Ă�z��
        gameObject.tag = "Enemy";

        audioSource = GetComponent<AudioSource>();  // AudioSource�̎擾
    }

    // ��Spawner����K���ĂԁF����Łu��^=10HP�v���m���ɔ��f�����
    public void Initialize(int hp, int score)
    {
        maxHP = hp;
        scoreOnKill = score;
        currentHP = hp; // Awake�̏���������ł��m���ɏ㏑��
        isDead = false;
    }


    public void TakeDamage(int dmg)
    {
        if (isDead) return;

        currentHP -= dmg;

        // �_���[�W���󂯂��Ƃ��̉��ƃG�t�F�N�g
        if (damageSound && audioSource)
        {
            audioSource.PlayOneShot(damageSound);  // �_���[�W�����Đ�
        }
        if (damageEffect)
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);  // �_���[�W�G�t�F�N�g�𐶐�
        }

        if (currentHP <= 0)
        {
            Die();  // ���S�������Ăяo��
        }
    }

    void Die()
    {
        if (isDead) return;  // ���Ɏ���ł���ꍇ�͏������Ȃ�
        isDead = true;  // ���S�t���O�𗧂Ă�

        audioSource.PlayOneShot(deathSound);  // ���S�����Đ�
        Instantiate(deathEffect, transform.position, Quaternion.identity);  // ���S�G�t�F�N�g�𐶐�

        // �X�R�A���Z����
        if (Score.instance != null)
        {
            Score.instance.AddScore(scoreOnKill);
        }

        // �I�u�W�F�N�g���폜
        Destroy(gameObject);
    }
}
