using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Distortion: MonoBehaviour
{

    public Transform targetTransform;


    private MeshRenderer _renderer;

    [Range(0, 5)]
    public float distortion = 1;


    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        Vector3 pos = targetTransform.position;

        float x = Mathf.Sin((pos.x * 10) % 10 / 10) / 60;
        float y = Mathf.Sin((pos.y * 10) % 10 / 10) / 60;
        float z = Mathf.Sin((pos.z * 10) % 10 / 10) / 60;

        Vector4 position = new Vector4(x * distortion, y * distortion, z * distortion, 0);
        foreach (Material m in _renderer.sharedMaterials)
        {
            m.SetVector("_Position", position);
        }
    }


    private void OnDisable()
    {
        Vector4 position = new Vector4(0, 0, 0, 0);
        foreach (Material m in _renderer.sharedMaterials)
        {
            m.SetVector("_Position", position);
        }
    }
}
