using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Frame: MonoBehaviour
{
    public float Scale = 1;
    
    [Range(0.01f, 30)]
    public float Radius = 13f;

    public bool Squared = false;

    [Range(0.01f, 1)]
    public float Height = 0.8f;

    [Range(0.01f, 1)]
    public float Width = 0.8f;

    public Color Color = Color.white;

    [SerializeField] private Image center;
    [SerializeField] private Image top;
    [SerializeField] private Image left;
    [SerializeField] private Image right;
    [SerializeField] private Image bottom;


    private void Update()
    {
        center.pixelsPerUnitMultiplier = Radius;
        center.color = Color;
        top.color = Color;
        left.color = Color;
        right.color = Color;
        bottom.color = Color;

        float centerHeight = Height * Screen.height;
        float centerWidth = Squared ? centerHeight : Width * Screen.width;

        center.rectTransform.sizeDelta = new Vector2(centerWidth / Scale, centerHeight / Scale);

        float topHeight = (Screen.height - centerHeight) / 2;
        top.rectTransform.sizeDelta = new Vector2(0, topHeight / Scale);
        bottom.rectTransform.sizeDelta = new Vector2(0, topHeight / Scale);

        float leftWidth = (Screen.width - centerWidth) / 2;
        left.rectTransform.sizeDelta = new Vector2(leftWidth / Scale, 0);
        right.rectTransform.sizeDelta = new Vector2(leftWidth / Scale, 0);

    }
}
