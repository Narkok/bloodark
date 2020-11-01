using UnityEngine;

public class PlayerManager: MonoBehaviour
{

    public Transform Player { get { return player; } }
    private Transform player;


    private void Start()
    {
        CreatePlayer();
    }


    private void CreatePlayer()
    {
        Vector3 position = Managers.instance.City.PlayerSpawnPoint;
        GameObject go = Instantiate(Resources.Load(Constants.Resources.Player) as GameObject, position, Quaternion.identity);
        player = go.transform;
    }    
}