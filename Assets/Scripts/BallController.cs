using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    private Vector3 direction;
    private Rigidbody rb;
    private bool stopped = true;
    private float minDirection = 0.5f; // You can uncomment this line if needed

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Update method typically handles input and user interactions.
    }

    void FixedUpdate()
    {
        if (stopped)
            return;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z; // Reflect the ball's direction upon hitting a wall.
        }
        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;

            // Limit the newDirection components while preserving their signs.
            // You might want to uncomment the minDirection line for this to work.
             newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), minDirection);
             newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), minDirection);

            direction = newDirection; // Set the ball's direction based on interaction with a racket.
        }
    }

    private void ChooseDirection()
    {
        // Randomly generate a new direction for the ball.
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        direction = new Vector3(signX * 0.5f, 0, signZ * 0.5f).normalized;
    }

    public void Stop()
    {
        this.stopped = true;
    }

    public void Go()
    {
        ChooseDirection(); // Randomly select a direction for the ball.
        this.stopped = false; // Start moving the ball.
    }
}
