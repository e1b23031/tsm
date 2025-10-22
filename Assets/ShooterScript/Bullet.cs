using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public float lifeTime = 5f;
    public int scoreValue = 10;
    private bool hasHit = false;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.useGravity = false;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.interpolation = RigidbodyInterpolation.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    public void Fire(Vector3 direction)
    {
        if (!rb) return;
        rb.linearVelocity = direction.normalized * speed;
        Destroy(gameObject, lifeTime);
    }

    //  Trigger専用にする
    void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        // 敵のHPコンポーネントを探す
        var hp = other.GetComponent<EnemyHealth>();
        if (hp == null)
        {
            // 子オブジェクトにColliderが付く構成なら親から探す
            hp = other.GetComponentInParent<EnemyHealth>();
        }

        if (hp != null)
        {
            hasHit = true;

            // 1ヒット＝1ダメージ（必要なら弾ごとにダメージ量をpublic化）
            hp.TakeDamage(1);

            // 弾はヒットしたら消す（多段ヒットを狙うならここを残存に）
            Destroy(gameObject);
        }
    }
}
