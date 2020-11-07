using UnityEngine;

public class Health: MonoBehaviour
{

    [SerializeField]
    private float _hp = 40;

    [SerializeField]
    private float _maxHP = 40;


    private void Awake()
    {
        _hp = _maxHP;
    }
}
