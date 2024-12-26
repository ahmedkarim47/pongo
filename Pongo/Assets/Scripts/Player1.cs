using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //determines movement speed for player 1's paddle
    public float paddleSpeed;

    //abbreviation of rigidbody is called rb
    private Rigidbody2D rb;
    //the x and y axis of the paddle is named paddledirection
    private Vector2 paddleDirection;

    private
    // Start is called before the first frame update
    void Start()
    {
        //fetches the rigidbody2d from player 1 object in unity
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //required for getting input from player 1
        float directionY = Input.GetAxisRaw("Vertical");

        //determines the direction of paddle in the y-axis
        paddleDirection = new Vector2(0, directionY).normalized;
    }

    //fixed update is used in physics frames
    //it is necessary for my project since i have used the in built unity physics feautures 

    private void FixedUpdate()
    {
        //speed of paddle is equal to the direction of travel times the paddle speed
        rb.velocity = paddleDirection * paddleSpeed;
    }
}
