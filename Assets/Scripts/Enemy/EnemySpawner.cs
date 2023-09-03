using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class EnemySpawner : SingletonGeneric<EnemySpawner>
{
    [SerializeField] private EnemyScriptableObjectList enemyList;
    private Vector3 randomPoint;
    private Coroutine spawnCoroutine = null;
    [SerializeField] private int spawnCount;
    [SerializeField] private float range;
    private bool isRunning;

    [SerializeField] public List<EnemyController> ListofEnemies { get; private set; } = new List<EnemyController>();

    // Start is called before the first frame update
    private void Start()
    {
        isRunning = false;
        for(int i  = 0; i < spawnCount; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (RandomPoint(Vector3.zero, range, out randomPoint) && spawnCount > 0)
                    break;
            }
            SpawnEnemy(randomPoint);
        }
        

    }
    void Update()
    {
        //if(RandomPoint(Vector3.zero, range, out randomPoint) && spawnCount > 0)
        //{
        //    if(spawnCoroutine == null)
        //    {
        //        spawnCoroutine = StartCoroutine(SpawnAtRandomPoint());
        //    }
        //    else
        //    {
        //        if (!isRunning)
        //        {
        //            StopCoroutine(spawnCoroutine);
        //            spawnCoroutine = null;
        //        }
        //    }
        //}
    }

    IEnumerator SpawnAtRandomPoint()
    {
        isRunning = true;
        yield return new WaitForSeconds(3);
        SpawnEnemy(randomPoint);
        spawnCount--;
        isRunning = false;
    }
    
    private void SpawnEnemy(Vector3 spawnPoint)
    {
        int randomNumber = (int)Random.Range(0f, enemyList.enemies.Length - 1);
        EnemyScriptableObject obj = enemyList.enemies[randomNumber];
        EnemyModel model = new EnemyModel(obj);
        EnemyController enemyController = new EnemyController(model, obj.enemyView, spawnPoint);
        ListofEnemies.Add(enemyController);
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
