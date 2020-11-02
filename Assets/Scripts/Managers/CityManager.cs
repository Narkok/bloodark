﻿using UnityEngine;
using System.Linq;

public class CityManager: MonoBehaviour, IManager
{

    public Transform City { get { return city; } }
    private Transform city;

    public Vector3 PlayerSpawnPoint { get { return playerSpawnPoint; } }
    private Vector3 playerSpawnPoint;

    public Vector3[] ZomboSpawnPoints { get { return zomboSpawnPoints; } }
    private Vector3[] zomboSpawnPoints;


    void IManager.Init()
    {
        LoadCity();

        GetSpawnPoints();
    }


    private void LoadCity()
    {
        city = GameObject.Find(Constants.Resources.City).transform;
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
