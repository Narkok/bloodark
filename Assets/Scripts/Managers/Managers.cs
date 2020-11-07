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

    private PlayerManager playerManager;
    public PlayerManager PlayerManager {
        get {
            if (playerManager == null) playerManager = GetComponent<PlayerManager>();
            return playerManager;
        }
    }

    private UIManager uiManager;
    public UIManager UI {
        get {
            if (uiManager == null) uiManager = GetComponent<UIManager>();
            return uiManager;
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
        (Enemy as IManager).Init();
    }
}