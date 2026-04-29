using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float runMultiplier = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        movement.x = inputX * (isRunning ? runMultiplier : 1f);

        animator.SetBool("isRunning", isRunning && Mathf.Abs(inputX) > 0);

        if (inputX > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (inputX < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}