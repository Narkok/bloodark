using UnityEngine;

public class AppearanceManager: MonoBehaviour
{

    public bool CursorIsVisible = false;

    public bool Fog = false;

    public bool Pixelation = false;

    public bool Distortion = false;

    public bool Rain = false;


    private void Start()
    {
        Cursor.visible = CursorIsVisible;

        RenderSettings.fog = Fog;
    }
}
