using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public float lifeTime = 5f;
    public int scoreValue = 10;
<<<<<<< Updated upstream
=======
    private bool hasHit = false;
>>>>>>> Stashed changes
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

    // ✅ Trigger専用にする
    void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;
        hasHit = true;

        if (other.CompareTag("Enemy"))
        {
<<<<<<< Updated upstream
            Destroy(Enemy.gameObject);  // 敵を消す
            Destroy(gameObject);        // 弾も消す


=======
            Destroy(other.gameObject);
            Destroy(gameObject);
>>>>>>> Stashed changes

            if (Score.instance != null)
            {
                Score.instance.AddScore(scoreValue);
            }
        }


    }
}
