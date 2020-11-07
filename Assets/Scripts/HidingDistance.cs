using UnityEngine;

public class HidingDistance: MonoBehaviour
{

    [SerializeField]
    private float _distance = 20;

    private Transform _mainCamera;
    private Transform _transform;

    private bool isHidden = false;


    void Start()
    {
        _transform = transform;
        _mainCamera = FindObjectOfType<Camera>().transform;
    }


    void Update()
    {
        bool needHide = Vector3.Distance(_transform.position, _mainCamera.position) > _distance;
        if (needHide == isHidden) return;
        isHidden = needHide;
        foreach (Transform child in _transform) child.gameObject.SetActive(!isHidden);
    }
}
