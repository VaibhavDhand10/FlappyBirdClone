using UnityEngine;
using UnityEngine.InputSystem;

public class BirdBehaviour : MonoBehaviour
{
    public BirdInput input {  get; private set; }
    private Rigidbody2D rb;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private float velocity = 10f;
    [SerializeField] private float rotationVelocity = 10f;

    private void Awake()
    {
        input = new BirdInput();
    }

    private void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        input.Enable();
    }

    private void Update()
    {
        if(input.Bird.Flap.WasPressedThisFrame())
        {
            rb.linearVelocity = Vector2.up * velocity;
        }

        // Touch support (anywhere on screen)
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector2.up * velocity;
        }
        Debug.Log(Touchscreen.current.primaryTouch.position.ReadValue());
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rb.linearVelocity.y * rotationVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}