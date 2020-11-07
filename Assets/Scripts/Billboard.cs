using UnityEngine;

public class Billboard: MonoBehaviour
{

    private Transform _mainCamera;
    private Transform _transform;


    void Start()
    {
        _transform = transform;
        _mainCamera = FindObjectOfType<Camera>().transform;
    }


    private void LateUpdate()
    {
        _transform.LookAt(_transform.position + _mainCamera.forward);
    }
}
