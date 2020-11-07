using UnityEngine;

public class PlayerManager: MonoBehaviour
{

    public PlayerController Player { get { return _player; } }
    private PlayerController _player;


    private void Start()
    {
        CreatePlayer();
    }


    private void CreatePlayer()
    {
        Vector3 position = Managers.instance.City.PlayerSpawnPoint;
        GameObject go = Instantiate(Resources.Load(Constants.Resources.Player) as GameObject, position, Quaternion.identity);
        _player = go.GetComponent<PlayerController>();

        Messenger.Broadcast(GameEvents.PLAYER_DID_SPAWN);
    }    
}