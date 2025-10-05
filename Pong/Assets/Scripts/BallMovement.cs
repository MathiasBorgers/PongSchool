using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float startSpeed;
    public float extraSpeed;

    public bool player1Start;
    public float maxExtraSpeed;

    private int hitCounter = 0;
    private Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());


    }

    void RestartBall()
    {

        rb.linearVelocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
;
    }

    public IEnumerator Launch()
    {
        RestartBall();
        
        hitCounter = 0;
        yield return new WaitForSeconds(1);
        if (player1Start)
        {
            MoveBall(new Vector2(1, 0));
        }

        else
        {
         MoveBall(new Vector2(1, 0));   
        }
        
    }
    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed;

        Debug.Log($"Ball direction: {direction}, Ball speed: {ballSpeed}");

        rb.linearVelocity = direction * ballSpeed;
    }
    
    public void IncreaseHitCounter()
    {
        
        if (hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }


}
