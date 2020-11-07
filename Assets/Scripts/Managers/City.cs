using UnityEngine;
using System.Linq;
using System;

public class City: MonoBehaviour
{

    public event Action LoadEvent;

    public Transform Transform { get { return _city; } }
    private Transform _city;

    public Vector3 PlayerSpawnPoint { get { return _playerSpawnPoint; } }
    private Vector3 _playerSpawnPoint;

    public Vector3[] ZomboSpawnPoints { get { return _zomboSpawnPoints; } }
    private Vector3[] _zomboSpawnPoints;

    [SerializeField]
    private bool _loadFromResources = true;


    public void Load()
    {
        if (_city != null)
        {
            LoadEvent?.Invoke();
            return;
        }

        if (_loadFromResources)
        {
            GameObject go = Instantiate(Resources.Load(Constants.Resources.City) as GameObject);
            go.transform.parent = null;
            _city = go.transform;
        }
        else
        {
            _city = GameObject.Find(Constants.Resources.City).transform;
        }

        GetSpawnPoints();

        LoadEvent?.Invoke();
    }


    private void GetSpawnPoints()
    {
        _zomboSpawnPoints = _city
            .GetComponentsInChildren<ZomboSpawnPoint>()
            .Select(point => point.transform.position)
            .ToArray();

        _playerSpawnPoint = _city
            .GetComponentInChildren<PlayerSpawnPoint>()
            .transform.position;
    }
}
