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
        appearanceManager = CreateAppearanceManager();
        cityManager = CreateCityManager();
        enemySpawnManager = CreateEnemySpawnManager();
        playerSpawnManager = CreatePlayerSpawnManager();
    }


    private EnemySpawnManager CreateEnemySpawnManager()
    {
        GameObject go = new GameObject("EnemySpawnManager");
        go.AddComponent<EnemySpawnManager>();
        go.transform.parent = transform;
        return go.GetComponent<EnemySpawnManager>();
    }


    private PlayerSpawnManager CreatePlayerSpawnManager()
    {
        GameObject go = new GameObject("PlayerSpawnManager");
        go.AddComponent<PlayerSpawnManager>();
        go.transform.parent = transform;
        return go.GetComponent<PlayerSpawnManager>();
    }


    private AppearanceManager CreateAppearanceManager()
    {
        GameObject go = new GameObject("AppearanceManager");
        go.AddComponent<AppearanceManager>();
        go.transform.parent = transform;
        return go.GetComponent<AppearanceManager>();
    }


    private CityManager CreateCityManager()
    {
        GameObject go = new GameObject("CityManager");
        go.AddComponent<CityManager>();
        go.transform.parent = transform;
        return go.GetComponent<CityManager>();
    }
}