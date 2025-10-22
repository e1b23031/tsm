using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyHealth : MonoBehaviour
{
    [Header("HP / Score")]
    public int maxHP = 3;        // �f�t�H���g�BSpawner����㏑�������
    public int scoreOnKill = 10;

    int currentHP = 0;
    bool isDead = false;

    void Awake()
    {
        // Spawner����Initialize����Ȃ������ꍇ�̕ی�
        if (currentHP <= 0) currentHP = maxHP;

        var col = GetComponent<Collider>();
        col.isTrigger = true; // �e��OnTriggerEnter�œ��Ă�z��
        gameObject.tag = "Enemy";
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
        if (currentHP <= 0) Die();
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        if (Score.instance != null) Score.instance.AddScore(scoreOnKill);
        Destroy(gameObject);
    }
}
