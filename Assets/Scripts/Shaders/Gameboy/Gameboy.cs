using UnityEngine;

public class Gameboy: MonoBehaviour
{

    public Material gameboyMaterial;
    public Material identityMaterial;

    private RenderTexture _downscaledRenderTexture;

    public int Height = 144;


    private void OnEnable()
    {
        var camera = GetComponent<Camera>();
        int width = Mathf.RoundToInt(camera.aspect * Height);
        _downscaledRenderTexture = new RenderTexture(width, Height, 16);
        _downscaledRenderTexture.filterMode = FilterMode.Point;
    }


    private void OnDisable()
    {
        Destroy(_downscaledRenderTexture);
    }


    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, _downscaledRenderTexture, gameboyMaterial);
        Graphics.Blit(_downscaledRenderTexture, dst, identityMaterial);
    }
}