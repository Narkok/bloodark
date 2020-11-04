using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager: MonoBehaviour, IManager
{
    [SerializeField]
    private float smoothTime = 5;

    [SerializeField]
    private Slider healthBar;
    private float targetHealthValue;

    [SerializeField]
    private Slider staminaBar;
    private float targetStaminaValue;


    void IManager.Init()
    {
        healthBar.maxValue = Constants.Game.PlayerHP;
        targetHealthValue = Constants.Game.PlayerHP;

        staminaBar.maxValue = Constants.Game.PlayerStamina;
        targetStaminaValue = Constants.Game.PlayerStamina;
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


    public void UpdateHealth(float value)
    {
        targetHealthValue = value;
    }


    public void UpdateStamina(float value)
    {
        targetStaminaValue = value;
    }
}
