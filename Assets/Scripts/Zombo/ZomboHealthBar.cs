using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZomboHealthBar: MonoBehaviour
{
    [SerializeField]
    private float smoothTime = 5;

    private Slider healthBar;
    private float targetHealthValue;


    private void Awake()
    {
        healthBar = GetComponent<Slider>();
        targetHealthValue = healthBar.maxValue;
    }


    private void Update()
    {
        float t = smoothTime * Time.deltaTime;
        if (targetHealthValue != healthBar.value)
            healthBar.value = Mathf.Lerp(healthBar.value, targetHealthValue, t);
    }


    public void UpdateHealth(float value)
    {
        targetHealthValue = value;
    }


    public void SetMaxHealth(float value)
    {
        healthBar.maxValue = value;
        targetHealthValue = value;
    }
}
