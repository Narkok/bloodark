using UnityEngine;

public class Managers: MonoBehaviour
{

    public static Managers instance = null;

    public EnemySpawnManager EnemySpawn { get { return enemySpawnManager; } }
    private EnemySpawnManager enemySpawnManager;

    public CityManager City { get { return cityManager; } }
    private CityManager cityManager;

    public AppearanceManager Appearance { get { return appearanceManager; } }
    private AppearanceManager appearanceManager;

    public PlayerSpawnManager PlayerSpawn { get { return playerSpawnManager; } }
    private PlayerSpawnManager playerSpawnManager;


    private void Start()
    {
        if (instance == null) instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        GenerateManagers();
    }


    private void GenerateManagers()
    {
        appearanceManager = Create<AppearanceManager>();
        cityManager = Create<CityManager>();
        enemySpawnManager = Create<EnemySpawnManager>();
        playerSpawnManager = Create<PlayerSpawnManager>();
    }


    private T Create<T>() where T: MonoBehaviour
    {
        string name = typeof(T).Name;
        GameObject go = new GameObject(name);
        go.AddComponent<T>();
        go.transform.parent = transform;
        return go.GetComponent<T>();
    }
}