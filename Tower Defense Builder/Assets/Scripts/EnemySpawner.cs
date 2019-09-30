using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public CheckPoints checkpoints;
    public Enemies enemies;
    public GameObject enemyPrefab;

    public GameObject enemyContainer;

    [Header("Enemies in wave")]
    public int maxAmountOfEnemies = 10;
    public int minAmountOfEnemies = 3;

    public float timeBetweenEnemySpawn = 0.8f;
    float waitTime = 0;

    public float timeBetweenWaves = 5.0f;
    float timeTillNextWave = 0;

    int currEnemyNum = 0;
    bool waveSpawned = false;
    [SerializeField]
    int numOfEnemiesToSpawn = 0;

    // Use this for initialization
    void Start()
    {
        checkpoints = CheckPoints.Instance;
        enemies = Enemies.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnWave();
    }

    // spawn a wave
    void SpawnWave()
    {
        // check if wave is spawned
        if (!waveSpawned)
        {
            // check if wave is ready to spawn
            if (timeTillNextWave > 0)
            {
                timeTillNextWave -= Time.deltaTime;
                return;
            }

            numOfEnemiesToSpawn = Random.Range(minAmountOfEnemies, maxAmountOfEnemies);
            waveSpawned = true;
            timeTillNextWave = timeBetweenWaves;
            return;
        }

        // check if it is time for next enemy spawn
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            return;
        }

        SpawnEnemy();
        currEnemyNum++;

        // reset wait time
        waitTime = timeBetweenEnemySpawn;
        
        // check if all enemies are spawned
        if (numOfEnemiesToSpawn == currEnemyNum)
        {
            currEnemyNum = 0;
            waveSpawned = false;
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemies.enemies[0].prefab, checkpoints.startPoint.position, Quaternion.identity);
        enemy.transform.SetParent(enemyContainer.transform);

        enemy.GetComponent<EnemyController>().info = enemies.enemies[0];

        enemies.enemyList.Add(enemy);
    }
}
