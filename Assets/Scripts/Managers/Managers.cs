using UnityEngine;

public class Managers: MonoBehaviour
{

    public static Managers instance = null;

    public EnemyManager EnemySpawn { get { return enemyManager; } }
    private EnemyManager enemyManager;

    public CityManager City { get { return cityManager; } }
    private CityManager cityManager;

    public AppearanceManager Appearance { get { return appearanceManager; } }
    private AppearanceManager appearanceManager;

    public PlayerManager Player { get { return playerManager; } }
    private PlayerManager playerManager;


    private void Start()
    {
        if (instance == null) instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        CollectManagers();
    }


    private void CollectManagers()
    {
        appearanceManager = GetComponentInChildren<AppearanceManager>();
        cityManager = GetComponentInChildren<CityManager>();
        enemyManager = GetComponentInChildren<EnemyManager>();
        playerManager = GetComponentInChildren<PlayerManager>();
    }


    private void GenerateManagers()
    {
        appearanceManager = Create<AppearanceManager>();
        cityManager = Create<CityManager>();
        enemyManager = Create<EnemyManager>();
        playerManager = Create<PlayerManager>();
    }


    private T Create<T>() where T : MonoBehaviour
    {
        string name = typeof(T).Name;
        GameObject go = new GameObject(name);
        go.AddComponent<T>();
        go.transform.parent = transform;
        return go.GetComponent<T>();
    }
}