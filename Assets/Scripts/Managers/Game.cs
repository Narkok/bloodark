using UnityEngine;


public class Game: MonoBehaviour
{

    public static Game instance = null;


    private ZomboSpawnManager _zomboSpawnManager;
    public ZomboSpawnManager ZomboSpawnManager { get { return _zomboSpawnManager; } }


    private City _city;
    public City City { get { return _city; } }


    private PlayerSpawnManager _playerSpawnManager;
    public PlayerSpawnManager PlayerSpawnManager { get { return _playerSpawnManager; } }


    private Player _player;
    public Player Player { get { return _player; } }


    [SerializeField]
    private UIManager _ui;
    public UIManager UI { get { return _ui; } }


    private void Awake()
    {
        if (instance == null) instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        LoadGame();
    }


    private void LoadGame()
    {
        LoadCity();
    }


    private void LoadCity()
    {
        Messenger.AddListener(GameEvent.CITY_DID_LOAD, LoadPlayer);

        _city = GetComponent<City>();
        _city.Load();
    }


    private void LoadPlayer()
    {
        Messenger.RemoveListener(GameEvent.CITY_DID_LOAD, LoadPlayer);
        Messenger.AddListener(GameEvent.PLAYER_DID_SPAWN, LoadZomboSpawnManager);

        _playerSpawnManager = GetComponent<PlayerSpawnManager>();
        _player = _playerSpawnManager.Spawn();
        _ui?.ConnectPlayer(_player);
    }


    private void LoadZomboSpawnManager()
    {
        Messenger.RemoveListener(GameEvent.PLAYER_DID_SPAWN, LoadZomboSpawnManager);

        _zomboSpawnManager = GetComponent<ZomboSpawnManager>();
        _zomboSpawnManager.StartSpawn();
    }
}