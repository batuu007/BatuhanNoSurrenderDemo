using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Enemy[] enemyx;

    private Vector3 enemyPosition;
    private float positionX;
    private float positionY;
    private float positionZ;
    private float enemyPositionY = 0.35f;

    private bool spawn = true;

    IEnumerator Start()
    {
        positionX = transform.position.x;
        positionZ = transform.position.z;
        positionY = transform.position.y + enemyPositionY;
        enemyPosition = new Vector3(positionX, positionY,positionZ);

        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyx.Length);
        Spawn(enemyx[enemyIndex]);
    }
    private void Spawn(Enemy enemy)
    {
        Enemy newEnemy = Instantiate(enemy, enemyPosition, Quaternion.identity);
        newEnemy.transform.parent = transform;
    }
}

