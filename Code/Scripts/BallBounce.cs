using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    //making variable for hit sound effect
    public GameObject hitSFX;
    //this code is to utilize  the increashitcounter algorithm presented in another script
    public BallMovement ballMovement;
    //reference to scoremanager script for scoring functionality
    public ScoreManager scoreManager;

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        //getting the position of the object the ball had collision with
        Vector3 paddlePosition = collision.transform.position;
        //to know which side of the paddle the ball made contact with
        float paddleHeight = collision.collider.bounds.size.y;

        //following code required to know if the ball hit p1 or p2 paddle
        float positionX;
        if(collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }

        else
        {
            positionX = -1;
        }
        float positionY = (ballPosition.y - paddlePosition.y) / paddleHeight;

        //increases amount of hits
        ballMovement.IncreaseHitCounter();
        //moves the ball along the axes
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    //following code required to detect collision

    //collision2d parameter is named collision
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        //detects if ball has made contact with a paddle
        if (collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            //contact with paddle results in the ball bouncing off
            Bounce(collision);
        }

        //checks if ball touched right side
        else if(collision.gameObject.name == "Right Side")
        {
            //gives p1 a point
            //player1goal variable was called from scoremanager script
            scoreManager.Player1Goal();

            //if p1 scored a goal then set variable to false so that p2 gets the ball next round
            ballMovement.player1Start = false;
            //calling launch coroutine
            StartCoroutine(ballMovement.Launch());
        }
        //checks if ball touched left side
        else if (collision.gameObject.name == "Left Side")
        {
            //gives p2 a point
            scoreManager.Player2Goal();

            //if p2 scored a goal then set variable to true so that p1 gets the ball next round
            ballMovement.player1Start = true;
            //calling launch coroutine
            StartCoroutine(ballMovement.Launch());
        }

        //makes sound effects depending on the position the ball is in
        Instantiate(hitSFX, transform.position, transform.rotation);
    }
}
