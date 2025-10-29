using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyHealth : MonoBehaviour
{
    [Header("HP / Score")]
    public int maxHP = 3;        // デフォルト。Spawnerから上書きされる
    public int scoreOnKill = 10;

    [Header("Sound Effect")]
    public AudioClip hitSound;  // ダメージ・死亡時の同じ音
    private AudioSource audioSource;

    int currentHP = 0;
    bool isDead = false;

    void Awake()
    {
        if (currentHP <= 0) currentHP = maxHP;

        var col = GetComponent<Collider>();
        col.isTrigger = true; // 弾はOnTriggerEnterで当てる想定
        gameObject.tag = "Enemy";

        audioSource = GetComponent<AudioSource>();  // AudioSourceの取得
    }

    // スポーン時に初期化される
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

        // 同じ音をダメージ時も死亡時も再生
        PlaySound(hitSound);  // ダメージ音（死亡時にも使用）

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // isDead がすでに true なら、処理を中断
        if (isDead) return;
        isDead = true;

        // 死亡音を再生（ダメージ音と同じ音）
        PlaySound(hitSound);  // 死亡音も同じ音を使用

        // スコア加算処理
        if (Score.instance != null)
        {
            Score.instance.AddScore(scoreOnKill);
        }

        // オブジェクトを削除
        Destroy(gameObject);
    }

    // 音を再生するメソッドを統一
    private void PlaySound(AudioClip sound)
    {
        if (sound != null && audioSource && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(sound);  // 音を再生
        }
    }
}
