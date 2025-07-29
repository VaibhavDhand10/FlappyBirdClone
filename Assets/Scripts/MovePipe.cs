using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}