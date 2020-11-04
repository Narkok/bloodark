using UnityEngine;


interface IManager
{
    void Init();
}


public class Managers: MonoBehaviour
{

    public static Managers instance = null;

    private EnemyManager enemyManager;
    public EnemyManager Enemy {
        get {
            if (enemyManager == null) enemyManager = GetComponent<EnemyManager>();
            return enemyManager;
        }
    }

    private CityManager cityManager;
    public CityManager City {
        get {
            if (cityManager == null) cityManager = GetComponent<CityManager>();
            return cityManager;
        }
    }

    private AppearanceManager appearanceManager;
    public AppearanceManager Appearance {
        get {
            if (appearanceManager == null) appearanceManager = GetComponent<AppearanceManager>();
            return appearanceManager;
        }
    }

    private PlayerManager playerManager;
    public PlayerManager PlayerManager {
        get {
            if (playerManager == null) playerManager = GetComponent<PlayerManager>();
            return playerManager;
        }
    }



    private void Awake()
    {
        if (instance == null) instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        (City as IManager).Init();
        (PlayerManager as IManager).Init();
        (Enemy as IManager).Init();
    }
}