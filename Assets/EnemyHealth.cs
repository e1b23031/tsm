using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyHealth : MonoBehaviour
{
    [Header("HP / Score")]
    public int maxHP = 3;        // デフォルト。Spawnerから上書きされる
    public int scoreOnKill = 10;

    [Header("Sound Effects")]
    public AudioClip damageSound;  // ダメージ時の音
    public AudioClip deathSound;   // 死亡時の音
    private AudioSource audioSource;

    [Header("Effects")]
    public GameObject damageEffect;  // ダメージ時のエフェクト
    public GameObject deathEffect;   // 死亡時のエフェクト

    int currentHP = 0;
    bool isDead = false;

    void Awake()
    {
        // SpawnerからInitializeされなかった場合の保険
        if (currentHP <= 0) currentHP = maxHP;

        var col = GetComponent<Collider>();
        col.isTrigger = true; // 弾はOnTriggerEnterで当てる想定
        gameObject.tag = "Enemy";

        audioSource = GetComponent<AudioSource>();  // AudioSourceの取得
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

        // ダメージを受けたときの音とエフェクト
        if (damageSound && audioSource)
        {
            audioSource.PlayOneShot(damageSound);  // ダメージ音を再生
        }
        if (damageEffect)
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);  // ダメージエフェクトを生成
        }

        if (currentHP <= 0)
        {
            Die();  // 死亡処理を呼び出す
        }
    }

    void Die()
    {
        if (isDead) return;  // 既に死んでいる場合は処理しない
        isDead = true;  // 死亡フラグを立てる

        audioSource.PlayOneShot(deathSound);  // 死亡音を再生
        Instantiate(deathEffect, transform.position, Quaternion.identity);  // 死亡エフェクトを生成

        // スコア加算処理
        if (Score.instance != null)
        {
            Score.instance.AddScore(scoreOnKill);
        }

        // オブジェクトを削除
        Destroy(gameObject);
    }
}
