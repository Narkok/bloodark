using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager: MonoBehaviour
{
    [SerializeField]
    private float smoothTime = 5;

    [SerializeField]
    private Slider healthBar;
    private float targetHealthValue;

    [SerializeField]
    private Slider staminaBar;
    private float targetStaminaValue;

    private PlayerController _player;


    private void Awake()
    {
        targetHealthValue = 1;
        targetStaminaValue = 1;
    }


    private void OnEnable()
    {
        Messenger.AddListener(GameEvents.PLAYER_DID_SPAWN, ConnectPlayer);
    }


    private void ConnectPlayer()
    {
        _player = FindObjectOfType<PlayerController>();
        _player.Health.ChangeEvent += UpdateHealth;
    }


    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvents.PLAYER_DID_SPAWN, ConnectPlayer);
        _player.Health.ChangeEvent -= UpdateHealth;
    }


    private void Update()
    {
        float t = smoothTime * Time.deltaTime;
        if (targetHealthValue != healthBar.value)
        {
            healthBar.value = Mathf.Lerp(healthBar.value, targetHealthValue, t);
        }

        if (targetStaminaValue != staminaBar.value)
        {
            staminaBar.value = Mathf.Lerp(staminaBar.value, targetStaminaValue, t);
        }
    }


    private void UpdateHealth(float value)
    {
        targetHealthValue = value;
    }


    public void UpdateStamina(float value)
    {
        targetStaminaValue = value;
    }
}
