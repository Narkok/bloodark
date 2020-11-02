using System.Collections;
using UnityEngine;

public class EnemyManager: MonoBehaviour, IManager
{

    public float SpawnDelay = 5;

    public int MaxLimit = 100;

    public int EnemyCount { get { return enemyCount; } }
    private int enemyCount = 0;


    private Transform enemyContainer;


    void IManager.Init()
    {
        CreateEnemyContainer();

        StartCoroutine(EnemyGenerator());
    }


    private void CreateEnemyContainer()
    {
        GameObject go = new GameObject(Constants.ObjectNames.EnemyContainer);
        enemyContainer = go.transform;
    }


    private void Spawn()
    {
        if (Managers.instance == null) return;
        if (Managers.instance.City == null) return;

        int index = Random.Range(0, Managers.instance.City.ZomboSpawnPoints.Length);
        Vector3 position = Managers.instance.City.ZomboSpawnPoints[index];

        GameObject go = Instantiate(Resources.Load(Constants.Resources.Zomb) as GameObject, position, Quaternion.identity);
        go.transform.parent = enemyContainer;

        enemyCount++;
    }


    private IEnumerator EnemyGenerator()
    {
        while (true)
        {
            if (enemyCount < MaxLimit) Spawn();
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
} 
