using UnityEngine;

public class PlayerManager: MonoBehaviour
{

    public Player Player { get { return _player; } }
    private Player _player;


    private void Start()
    {
        CreatePlayer();
    }


    private void CreatePlayer()
    {
        Vector3 position = Managers.instance.City.PlayerSpawnPoint;
        GameObject go = Instantiate(Resources.Load(Constants.Resources.Player) as GameObject, position, Quaternion.identity);
        _player = go.GetComponent<Player>();

        Messenger.Broadcast(GameEvents.PLAYER_DID_SPAWN);
    }    
}