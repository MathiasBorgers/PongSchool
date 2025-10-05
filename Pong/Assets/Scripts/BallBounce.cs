using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallBounce : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    public GameObject hitSFX;


    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if (collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        // Adjust positionY to ensure significant vertical movement
        float positionY = (ballPosition.y - racketPosition.y) / racketHeight; // Normalize to [-0.5, 0.5]
        positionY *= 2; // Scale to [-1, 1]
        positionY = Mathf.Clamp(positionY, -1f, 1f);

        Debug.Log($"Bounce direction: {positionX}, {positionY}");

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            Bounce(collision);
        }
        else if (collision.gameObject.name == "Left Border")
        {
            scoreManager.Player2Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }
        else if (collision.gameObject.name == "Right Border")
        {
            scoreManager.Player1Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }
}
