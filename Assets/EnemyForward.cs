using UnityEngine;
using System.Collections; // Coroutine用

public class EnemyForward : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float stopZ = -2f; // 敵が停止するZ座標（カメラ内）

    private Camera mainCamera;
    private bool isStopped = false; // 停止フラグ

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isStopped)
            return;

        // カメラの中心（0,0,0）より少し内向きに進む
        Vector3 targetPos = new Vector3(0, transform.position.y, 0);
        Vector3 direction = (targetPos - transform.position).normalized;

        // 内向きの補正（X軸を少し弱めにする）
        direction.x *= 0.3f;
        direction.y = 0;

        // 移動
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Z軸の停止位置制御
        if (transform.position.z >= stopZ)
        {
            // Z軸をstopZに固定
            transform.position = new Vector3(transform.position.x, transform.position.y, stopZ);

            // 停止フラグを立てる
            isStopped = true;

            // 停止後0.2秒で消す
            StartCoroutine(DestroyAfterDelay(0.2f));
        }

        // X軸の補正は停止前のみ
        if (!isStopped)
        {
            float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
            float clampedX = Mathf.Clamp(transform.position.x, -cameraWidth * 0.9f, cameraWidth * 0.9f);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

    // Coroutineで遅延Destroy
    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
