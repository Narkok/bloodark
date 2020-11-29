#if UNITY_EDITOR using UnityEditor; #endif using UnityEngine;  [ExecuteInEditMode] [RequireComponent(typeof(Camera))] public class RenderEffect: MonoBehaviour {      //public Material VignetteMaterial;     public int Height = 144;      private RenderTexture _downscaledRenderTexture;     private Camera _camera;       private void Awake()     {         _camera = GetComponent<Camera>();         CreateTexture();     }       #if UNITY_EDITOR     private void Update()     {         if (EditorApplication.isPlaying) return;         CreateTexture();     }     #endif       private void CreateTexture()     {         int width = Screen.width * Height / Screen.height;         _downscaledRenderTexture = new RenderTexture(width, Height, 2, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);new RenderTexture(width, Height, 2, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);         _downscaledRenderTexture.antiAliasing = 1;         _downscaledRenderTexture.filterMode = FilterMode.Point;     }


    private void OnPreRender()
    {
        if (_camera == null) return;
        _camera.targetTexture = _downscaledRenderTexture;
    }       private void OnRenderImage(RenderTexture src, RenderTexture dst)     {
        src.filterMode = FilterMode.Point;
        //Graphics.Blit(src, _downscaledRenderTexture, VignetteMaterial);
        //Graphics.Blit(_downscaledRenderTexture, dst);
        Graphics.Blit(src, dst);
    }


    private void OnPostRender()
    {
        if (_camera == null) return;
        _camera.targetTexture = null;
    } }