using UnityEngine;
using System;

public class PlayerSpawnManager: MonoBehaviour
{

    public event Action SpawnEvent;

    public Player Player { get { return _player; } }
    private Player _player;


    public Player Spawn()
    {
        if (_player != null)
        {
            SpawnEvent?.Invoke();
            return _player;
        }

        Vector3 position = Game.instance.City.PlayerSpawnPoint;
        GameObject go = Instantiate(Resources.Load(Constants.Resources.Player) as GameObject, position, Quaternion.identity);
        _player = go.GetComponent<Player>();

        SpawnEvent?.Invoke();
        return _player;
    }    
}