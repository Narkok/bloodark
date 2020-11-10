using UnityEngine;
using UnityEngine.UI;

public class ZomboHealthBar: MonoBehaviour
{
    [SerializeField]
    private Health _health;

    [SerializeField]
    private float smoothTime = 5;

    private Slider healthBar;
    private float targetHealthValue;


    private void Awake()
    {
        healthBar = GetComponent<Slider>();
        targetHealthValue = healthBar.maxValue;
        _health.ChangeEvent += UpdateHealth;
    }


    private void Update()
    {
        if (targetHealthValue != healthBar.value)
            healthBar.value = Mathf.Lerp(healthBar.value, targetHealthValue, smoothTime * Time.deltaTime);
    }


    public void UpdateHealth(float value)
    {
        targetHealthValue = value;
    }
}
