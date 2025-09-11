using UnityEngine;
using UnityEngine.InputSystem; // 新Input System

public class Shooter3D : MonoBehaviour
{
    public Camera cam;                   // カメラ
    public Transform crosshair;          // 3D照準
    public Bullet bulletPrefab;          // 弾プレハブ
    public float spawnForwardOffset = 0.1f; // 自己衝突回避のためのオフセット

    [Header("Time Limit Settings")]
    public float fireDuration = 10f;     // 撃てる時間（秒）
    private float fireEndTime;           // 撃てる終了時刻

    void Start()
    {
        if (!cam) cam = Camera.main;

        // ゲーム開始から fireDuration 秒後まで撃てる
        fireEndTime = Time.time + fireDuration;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // 制限時間内だけ発射可能
        if (Time.time < fireEndTime)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Fire();
            }
        }
        else
        {
            // デバッグ用：制限後にキーを押したら通知
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Debug.Log("時間切れ！もう撃てません。");
            }
        }
    }

    void Fire()
    {
        if (!cam || !crosshair || !bulletPrefab) return;

        Vector3 dir = (crosshair.position - cam.transform.position).normalized;
        Vector3 spawnPos = crosshair.position + dir * spawnForwardOffset;

        Bullet b = Instantiate(bulletPrefab, spawnPos, Quaternion.LookRotation(dir));
        b.Fire(dir);
    }
}
