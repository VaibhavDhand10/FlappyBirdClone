using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundImageAdjust : MonoBehaviour
{
    void Start()
    {
        FitToScreen();
    }

    void FitToScreen()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null || sr.sprite == null) return;

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = sr.sprite.bounds.size.x / sr.sprite.bounds.size.y;

        Vector3 scale = transform.localScale;

        if (screenRatio >= targetRatio)
        {
            // Wider than target: match width
            scale.x = Camera.main.orthographicSize * 2f * screenRatio / sr.sprite.bounds.size.x;
            scale.y = scale.x;
        }
        else
        {
            // Taller than target: match height
            scale.y = Camera.main.orthographicSize * 2f / sr.sprite.bounds.size.y;
            scale.x = scale.y;
        }

        transform.localScale = scale;
    }
}