using UnityEngine;

public class Player2 : MonoBehaviour
{

    public Rigidbody2D ball;
    public float maxSpeed = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Alleen bewegen als de bal naar Player2 komt
        if (ball.linearVelocity.x > 0)
        {
            float direction = Mathf.Sign(ball.position.y - transform.position.y);
            float distance = Mathf.Abs(ball.position.y - transform.position.y);
            float speed = Mathf.Min(maxSpeed, distance * 2f); // paddle versnelt als bal verder weg is
            rb.linearVelocity = new Vector2(0, direction * speed);
        }
        else
        {
            // Paddle stopt als bal niet naar Player2 beweegt
            rb.linearVelocity = Vector2.zero;
        }
    }
}
