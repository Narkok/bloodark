using System.Collections;
using UnityEngine;

public class ZomboSpawnManager: MonoBehaviour
{

    public float SpawnDelay = 5;

    public int MaxLimit = 100;

    public int EnemyCount { get { return enemyCount; } }
    private int enemyCount = 0;

    private Transform _enemyContainer;
    private Coroutine _zomboCoroutine;


    public void StartSpawn()
    {
        if (_enemyContainer == null) CreateEnemyContainer();
        if (_zomboCoroutine != null) StopCoroutine(_zomboCoroutine);
        _zomboCoroutine = StartCoroutine(EnemyGenerator());
    }


    public void StopSpawn()
    {
        if (_zomboCoroutine != null) StopCoroutine(_zomboCoroutine);
        _zomboCoroutine = null;
    }


    private void CreateEnemyContainer()
    {
        GameObject go = new GameObject(Constants.ObjectNames.EnemyContainer);
        _enemyContainer = go.transform;
    }


    private void Spawn(ZomboType zomboType)
    {
        int index = Random.Range(0, Game.instance.City.ZomboSpawnPoints.Length);
        Vector3 position = Game.instance.City.ZomboSpawnPoints[index];

        GameObject go = Instantiate(Resources.Load(zomboType.ZomboPath()) as GameObject, position, Quaternion.identity);
        go.transform.parent = _enemyContainer;

        enemyCount++;
    }


    private IEnumerator EnemyGenerator()
    {
        while (true)
        {
            if (enemyCount < MaxLimit) Spawn(ZomboType.Default);
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
} 
