using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;       // Enemy�v���n�u
    public float spawnInterval = 2f;     // �X�|�[���Ԋu
    public float spawnZ = -20f;          // �X�|�[���ʒuZ
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
        // �J�����̍��E�iX���j�͈͂��擾
        float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;

        // X���͏��������Ń����_����
        float randomX = Random.Range(-cameraWidth * 0.8f, cameraWidth * 0.8f);

        Vector3 spawnPos = new Vector3(randomX, 0.5f, spawnZ);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);


        Renderer renderer = enemy.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Random.ColorHSV(
                0f, 1f,    // �F���iHue�j
                0.6f, 1f,  // �ʓx�iSaturation�j
                0.8f, 1f   // ���x�iValue�j
            );
        }
    }
}
