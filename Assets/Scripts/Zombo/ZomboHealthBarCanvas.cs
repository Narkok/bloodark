using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZomboHealthBarCanvas: MonoBehaviour
{
    [SerializeField]
    private float smoothTime = 5;

    private Transform _mainCamera;
    private Transform _transform;

    [SerializeField]
    private float activeDistance = 20;

    private Slider healthBar;
    private float targetHealthValue;


    private void Awake()
    {
        _transform = transform;
        _mainCamera = GameObject.Find("Main Camera").transform;

        healthBar = GetComponentInChildren<Slider>();
        targetHealthValue = healthBar.maxValue;
    }


    private void Update()
    {
        float t = smoothTime * Time.deltaTime;
        if (targetHealthValue != healthBar.value)
        {
            healthBar.value = Mathf.Lerp(healthBar.value, targetHealthValue, t);
        }
    }


    private void LateUpdate()
    {
        healthBar.gameObject.SetActive(Vector3.Distance(_transform.position, _mainCamera.position) < activeDistance);
        _transform.LookAt(_transform.position + _mainCamera.forward);
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
