using UnityEngine;

public class Appearance: MonoBehaviour
{

    public bool CursorIsVisible = false;

    public bool Pixelation = false;

    public bool Distortion = false;


    private void Start()
    {
        Cursor.visible = CursorIsVisible;
    }
}
