using System.Collections;
using UnityEngine;

public class EnemySpawnManager: MonoBehaviour
{

    private Transform enemyContainer;


    private void Start()
    {
        Debug.Log("EnemySpawnManager Started");

        CreateEnemyContainer();
        StartCoroutine(SetGuard());
    }


    private void CreateEnemyContainer()
    {
        GameObject go = new GameObject("EnemyContainer");
        enemyContainer = go.transform;
    }


    private void Spawn()
    {
        int index = Random.Range(0, Managers.instance.City.ZomboSpawnPoints.Length);
        Vector3 position = Managers.instance.City.ZomboSpawnPoints[index];

        GameObject go = Instantiate(Resources.Load("Zomb") as GameObject, position, Quaternion.identity);
        go.transform.parent = enemyContainer;
    }


    private IEnumerator SetGuard()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            Spawn();
        }
    }
} 
