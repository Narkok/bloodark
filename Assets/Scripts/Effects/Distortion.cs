using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Distortion: MonoBehaviour
{

    public Transform targetTransform;


    public MeshRenderer _renderer;


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

        Vector4 position = new Vector4(x, y, z, 0);
        Debug.Log(position);
        foreach (Material m in _renderer.sharedMaterials)
        {
            m.SetVector("_Position", position);
        }
    }
}
