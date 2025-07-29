using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float width = 6f;

    private SpriteRenderer sr;
    private Vector2 startSize;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        startSize = new Vector2(sr.size.x, sr.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        sr.size = new Vector2(sr.size.x + speed * Time.deltaTime, sr.size.y);

        if (sr.size.x > width)
        {
            sr.size = startSize;
        }
    }
}