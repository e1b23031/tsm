using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnZ = -20f;

    [Header("Spawn Ratio (Normal:Big = 9:1)")]
    [Range(0f, 1f)] public float bigSpawnProbability = 0.1f;

    [Header("Normal Enemy")]
    public int normalHP = 3;
    public int normalScore = 10;
    public Vector3 normalScale = new Vector3(0.7f, 0.7f, 0.7f);

    [Header("Big Enemy")]
    public int bigHP = 10;
    public int bigScore = 30;
    public Vector3 bigScale = new Vector3(1.3f, 1.3f, 1.3f);

    float timer;
    Camera mainCamera;

    void Start() => mainCamera = Camera.main;

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
        float camWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float x = Random.Range(-camWidth * 0.8f, camWidth * 0.8f);
        Vector3 pos = new Vector3(x, 0.5f, spawnZ);

        GameObject go = Instantiate(enemyPrefab, pos, Quaternion.identity);

        bool isBig = Random.value < bigSpawnProbability;
        var hp = go.GetComponent<EnemyHealth>();
        if (hp == null) hp = go.AddComponent<EnemyHealth>();

        if (isBig)
        {
            go.transform.localScale = bigScale;
            hp.Initialize(bigHP, bigScore);            // ★ここが重要
            var r = go.GetComponent<Renderer>();
            if (r) r.material.color = Color.red;     // 見た目の区別
        }
        else
        {
            go.transform.localScale = normalScale;
            hp.Initialize(normalHP, normalScore);      // ★ここが重要
            var r = go.GetComponent<Renderer>();
            if (r) r.material.color = Color.white;
        }

        go.tag = "Enemy"; // 念のため明示
    }
}
