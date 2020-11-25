using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class TreeMaterialFixer: MonoBehaviour
{
    [SerializeField]
    private Material _barkMaterial;


    private void Awake()
    {
        GetComponent<MeshRenderer>().material = _barkMaterial;
    }
}
