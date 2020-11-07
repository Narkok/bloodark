using UnityEngine;

public class PlayerSpawnManager: MonoBehaviour
{

    public Player Player { get { return _player; } }
    private Player _player;


    public Player Spawn()
    {
        if (_player != null)
        {
            Messenger.Broadcast(GameEvent.PLAYER_DID_SPAWN);
            return _player;
        }

        Vector3 position = Game.instance.City.PlayerSpawnPoint;
        GameObject go = Instantiate(Resources.Load(Constants.Resources.Player) as GameObject, position, Quaternion.identity);
        _player = go.GetComponent<Player>();

        Messenger.Broadcast(GameEvent.PLAYER_DID_SPAWN);

        return _player;
    }    
}