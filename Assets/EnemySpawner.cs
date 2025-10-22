using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnZ = -20f;
    private float timer = 0f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float randomX = Random.Range(-cameraWidth * 0.8f, cameraWidth * 0.8f);

        Vector3 spawnPos = new Vector3(randomX, 0.5f, spawnZ);

        // 1回だけ生成！
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        Renderer renderer = enemy.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Random.ColorHSV(
                0f, 1f,    // 色相（Hue）
                0.6f, 1f,  // 彩度（Saturation）
                0.8f, 1f   // 明度（Value）
            );
        }
    }
}
