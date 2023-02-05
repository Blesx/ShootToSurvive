using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float ySpawnPoint;

    [SerializeField] GameObject coin;
    [SerializeField] float coinStartDelay;
    [SerializeField] float coinSpawnInterval;

    [SerializeField] List<Enemy> enemyPool;
    private float totalEnemySpawnWeight = 0;
    [SerializeField] float enemyStartDelay;
    [SerializeField] float enemySpawnInterval;
    [SerializeField] float enemyIncreaseRate;

    [SerializeField] List<Item> itemPool;
    private float totalItemSpawnWeight = 0;
    [SerializeField] float itemStartDelay;
    [SerializeField] float itemSpawnInterval;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        SortItemPool();
        SortEnemyPool();
        
        InvokeRepeating("SpawnItem", itemStartDelay, itemSpawnInterval);
        StartCoroutine(SpawnEnemy());
        InvokeRepeating("SpawnCoin", coinStartDelay, coinSpawnInterval);
    }

    // Sort item pool from highest probability to lowest and add up the total probability
    void SortItemPool()
    {
        itemPool.Sort( (item1, item2) => item2.GetSpawnProbability().CompareTo(item1.GetSpawnProbability()) );

        foreach (Item item in itemPool) {
            totalItemSpawnWeight += item.GetSpawnProbability();
        }
    }

    void SortEnemyPool()
    {
        enemyPool.Sort( (enemy1, enemy2) => enemy2.GetSpawnProbability().CompareTo(enemy1.GetSpawnProbability()) );

        foreach (Enemy enemy in enemyPool) {
            totalEnemySpawnWeight += enemy.GetSpawnProbability();
        }
    }

    void SpawnItem()
    {
        float chance = Random.Range(0, totalItemSpawnWeight);
        float cumulative = 0;

        foreach (Item item in itemPool) {
            cumulative += item.GetSpawnProbability();

            if (chance <= cumulative)
            {
                Instantiate(item, CalculateSpawnPos(), item.transform.rotation);
                break;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(enemyStartDelay);

        while (true)
        {
            float chance = Random.Range(0, totalEnemySpawnWeight);
            float cumulative = 0;

            foreach (Enemy enemy in enemyPool)
            {
                cumulative += enemy.GetSpawnProbability();

                if (chance <= cumulative)
                {
                    Instantiate(enemy, CalculateSpawnPos(), enemy.transform.rotation);
                    break;
                }
            }

            enemySpawnInterval *= enemyIncreaseRate;
            yield return new WaitForSeconds(enemySpawnInterval);

        }
    }

    void SpawnCoin()
    {
        Instantiate(coin, CalculateSpawnPos(), coin.transform.rotation);
    }

    Vector2 CalculateSpawnPos()
    {
        if (player.transform.position.x < 0)
        {
            return new Vector2(ySpawnPoint, 0);
        }
        return new Vector2(-ySpawnPoint, 0);
    }
}
