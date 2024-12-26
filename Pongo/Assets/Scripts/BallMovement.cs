using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //determines starting speed of ball
    public float startSpeed;
    //determines how much speed ball is going to increase upon contact with paddle
    public float extraSpeed;
    //determines the maximum extra speed for the ball
    public float maxExtraSpeed;

    //whenever this statement is true p1 starts off with the ball and when it is false p2 starts instead
    public bool player1Start = true;

    //to keep track of how many times the ball has been hit by the racket
    private int hitCounter = 0;

    //we need this because we use simple physics to move the ball
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        //to make ball stop moving
        rb.velocity = new Vector2(0, 0);
        //makes ball move back to the centre
        transform.position = new Vector2(0, 0);
    }

    //the next 2 lines were implemented in order for the ienumerator below it to work (c# generated)
    private void StartCouroutine(IEnumerator enumerator)
    {
        throw new NotImplementedException();
    }

    public IEnumerator Launch ()
    {
        RestartBall();
        hitCounter = 0;
        //makes game wait for 1 second before ball starts moving so players can get ready
        yield return new WaitForSeconds(1);

        //if statement to check if p1 or p2 starts with ball
        if(player1Start == true)
        {
            //this line of code results in ball moving to the left towards p1
            MoveBall(new Vector2(-1, 0));
        }
        else
        {
            //ball moves right towards p2
            MoveBall(new Vector2(1, 0));
        }
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        //determines ball speed according to how many times the paddle has made contact with the ball
        float ballSpeed = startSpeed + hitCounter * extraSpeed;
        //applies previous code to the physics aspect of the ball
        rb.velocity = direction * ballSpeed; 
    }

    //code required for ball speed to increase upon hit
    public void IncreaseHitCounter()
    {
        if (hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
