using UnityEngine;
using UnityEngine.InputSystem; // 新Input System

public class Shooter3D : MonoBehaviour
{
    public Camera cam;                   // 未設定なら自動でMainCamera
    public Transform crosshair;          // 3D照準(例: Crosshair3D)
    public Bullet bulletPrefab;          // 弾プレハブ
    public float spawnForwardOffset = 0.1f; // 照準から少し前に出す

    [Header("Optional")]
    public Collider shooterCollider;     // 自機など、弾と当てたくない発射元のCollider

    void Awake()
    {
        if (!cam) cam = Camera.main;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // 発射（Space）
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Fire();
        }
    }

    void Fire()
    {
        if (!cam || !crosshair || !bulletPrefab) return;

        // カメラ→照準の正確な方向
        Vector3 dir = (crosshair.position - cam.transform.position).normalized;

        // 照準位置から少し前にずらしてスポーン
        Vector3 spawnPos = crosshair.position + dir * spawnForwardOffset;

        Bullet b = Instantiate(bulletPrefab, spawnPos, Quaternion.LookRotation(dir));
        b.Fire(dir);

        // 発射元との自己衝突を無効化（必要なら）
        if (shooterCollider)
        {
            var bulletCol = b.GetComponent<Collider>();
            if (bulletCol) Physics.IgnoreCollision(bulletCol, shooterCollider, true);
        }
    }
}


