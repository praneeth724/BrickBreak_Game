using UnityEngine;

public class Brick : MonoBehaviour
{
    public int scoreValue = 0;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject); // Destroy the brick
            gameController.IncreaseScore(scoreValue); // Increase score
        }
    }
}
