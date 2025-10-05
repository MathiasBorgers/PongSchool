using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player1 : MonoBehaviour
{

    public float racketSpeed;

    private Rigidbody2D rb;


    public Vector2 racketDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");    

    }
    
private void FixedUpdate()
{
    float directionY = Input.GetAxisRaw("Vertical");
    rb.linearVelocity = new Vector2(0, directionY * racketSpeed);
}
}
