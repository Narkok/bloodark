#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class Pixelation : MonoBehaviour
{

    public bool UseScale = false;
    [Range(2, 16)] public float Scale = 6;

    public bool UseAbsolute = true;
    [Range(2, 2000)] public int Height = Screen.height;

    private Camera cameraComponent;
    private RenderTexture texture;


    private void Start()
    {
        CreateTexture();
    }


    private void CreateTexture()
    {
        int width = Screen.width;
        int height = Screen.height;

        if (UseScale)
        {
            width = Mathf.RoundToInt(Screen.width / Scale);
            height = Mathf.RoundToInt(Screen.height / Scale);
        }

        if (UseAbsolute)
        {
            height = Height;
            width = Screen.width * height / Screen.height;
        }    

        texture = new RenderTexture(width, height, 2, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
        texture.antiAliasing = 1;
        cameraComponent = GetComponent<Camera>();
    }


    #if UNITY_EDITOR
    private void Update()
    {
        if (EditorApplication.isPlaying) return;
        CreateTexture();
    }
    #endif


    private void OnPreRender()
    {
        if (cameraComponent == null) return;
        cameraComponent.targetTexture = texture;
    }


    private void OnPostRender()
    {
        if (cameraComponent == null) return;
        cameraComponent.targetTexture = null;
    }


    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        src.filterMode = FilterMode.Point;
        Graphics.Blit(src, dest);
    }
}
