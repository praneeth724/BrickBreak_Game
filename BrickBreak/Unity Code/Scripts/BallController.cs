using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb2d;
   
   

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void Update()
    {
        // Normalize velocity to maintain constant speed
        rb2d.velocity = rb2d.velocity.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            // Calculate the direction based on where the ball hits the paddle
            float hitPoint = other.contacts[0].point.x - other.gameObject.transform.position.x;
            Vector2 direction = new Vector2(hitPoint, 1f).normalized;

            // Apply a speed in the Y direction (vertical direction)
            float ySpeed = 50f; // Adjust this value as needed
            rb2d.velocity = direction * speed + Vector2.up * ySpeed;
        }
        else if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Brick"))
        {
            // Reflect ball off walls or bricks
            Vector2 reflection = CalculateReflection(rb2d.velocity, other.contacts[0].normal);
            rb2d.velocity = reflection.normalized * speed;
        }
        else if(other.gameObject.CompareTag("Down"))
        {

            SceneManager.LoadScene("Level");
        }
    }

    


    Vector2 CalculateReflection(Vector2 incomingVector, Vector2 collisionNormal)
    {
        return Vector2.Reflect(incomingVector, collisionNormal);
    }

    public void LaunchBall()
    {
        // Initial launch direction (upwards)
        Vector2 launchDirection = new Vector2(Random.Range(-0.5f, 0.5f), 1f).normalized;
        rb2d.velocity = launchDirection * speed;
    }
}
