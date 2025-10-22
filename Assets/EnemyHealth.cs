using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyHealth : MonoBehaviour
{
    [Header("HP / Score")]
    public int maxHP = 3;        // デフォルト。Spawnerから上書きされる
    public int scoreOnKill = 10;

    int currentHP = 0;
    bool isDead = false;

    void Awake()
    {
        // SpawnerからInitializeされなかった場合の保険
        if (currentHP <= 0) currentHP = maxHP;

        var col = GetComponent<Collider>();
        col.isTrigger = true; // 弾はOnTriggerEnterで当てる想定
        gameObject.tag = "Enemy";
    }

    // ★Spawnerから必ず呼ぶ：これで「大型=10HP」が確実に反映される
    public void Initialize(int hp, int score)
    {
        maxHP = hp;
        scoreOnKill = score;
        currentHP = hp; // Awakeの初期化より後でも確実に上書き
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
