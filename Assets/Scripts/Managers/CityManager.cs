using UnityEngine;
using System.Linq;

public class CityManager: MonoBehaviour
{
    public Transform City { get { return city; } }
    private Transform city;

    public Vector3 PlayerSpawnPoint { get { return playerSpawnPoint; } }
    public Vector3 playerSpawnPoint;

    public Vector3[] ZomboSpawnPoints { get { return zomboSpawnPoints; } }
    public Vector3[] zomboSpawnPoints;


    private void Start()
    {
        Debug.Log("CityManager Started");

        LoadCity();
        GetSpawnPoints();
    }


    private void LoadCity()
    {
        GameObject go = Resources.Load("City") as GameObject;
        city = go.transform;
        Instantiate(go);
    }


    private void GetSpawnPoints()
    {
        zomboSpawnPoints = city
            .GetComponentsInChildren<ZomboSpawnPoint>()
            .Select(point => point.transform.position)
            .ToArray();

        playerSpawnPoint = city
            .GetComponentInChildren<PlayerSpawnPoint>()
            .transform.position;
    }
}
