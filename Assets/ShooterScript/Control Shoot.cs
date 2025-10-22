
using UnityEngine;
using UnityEngine.InputSystem;

public class CrosshairGamepadShooter : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;                     // スティック移動速度
    public Vector2 limits = new Vector2(0.5f, 0.3f); // 可動範囲（左右x, 上下y）
    public float distanceFromCamera = 3f;            // カメラからの距離

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;                  // 弾プレハブ
    public float bulletSpeed = 10f;                  // 弾の速度
    public float shootInterval = 0.2f;               // 連射間隔（秒）

    private Camera cam;
    private Vector2 offset;
    private float lastShootTime = 0f;

    void Start()
    {
        cam = Camera.main;
        transform.localPosition = new Vector3(0f, 0f, distanceFromCamera);
    }

    void Update()
    {
        var pad = Gamepad.current;
        if (pad == null) return; // コントローラー未接続

        // 🎯 左スティックで照準移動
        Vector2 stick = pad.leftStick.ReadValue();
        offset += stick * moveSpeed * Time.deltaTime;
        offset.x = Mathf.Clamp(offset.x, -limits.x, limits.x);
        offset.y = Mathf.Clamp(offset.y, -limits.y, limits.y);
        transform.localPosition = new Vector3(offset.x, offset.y, distanceFromCamera);

        // 🔫 ZR または ZL トリガーで発射
        bool shootPressed =
            pad.rightTrigger.ReadValue() > 0.5f || pad.leftTrigger.ReadValue() > 0.5f;

        if (shootPressed && Time.time - lastShootTime >= shootInterval)
        {
            Fire();
            lastShootTime = Time.time;
        }
    }

    void Fire()
    {
        if (!bulletPrefab || !cam) return;

        // カメラから照準方向へのベクトル
        Vector3 dir = (transform.position - cam.transform.position).normalized;
        Vector3 spawnPos = transform.position + dir * 0.2f;

        // 弾生成
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.LookRotation(dir));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = dir * bulletSpeed;
        }

        Debug.Log("Fire!"); // 確認用
    }
}
