using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    //rigidbody component in ball is abbreviated as 'ball'
    public Rigidbody2D ball;
    //sets the ball's speed
    public float speed = 5.0f;
    //another rigidbody is abbreviated
    protected Rigidbody2D _rigidbody;

    private void Awake()
    {
        //makes it so the rigidbody in the ball is called upon
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    //physics related logic requires this:
    private void FixedUpdate()
    {

        if (this.ball.velocity.x > 0.0f)
        {
            //if ball position is greater than the ai paddle position
            if (this.ball.position.y > this.transform.position.y)
            {
                //then the ai will move its paddle up
                _rigidbody.AddForce(Vector2.up * this.speed);
            }
            //if ball position is less than the ai paddle position
            else if (this.ball.position.y < this.transform.position.y)
            {
                //then the ai will its paddle down
                _rigidbody.AddForce(Vector2.down * this.speed);
            }
            //if ball is moving away from the ai
            //ai paddle will idle in middle (makes ai smarter)
            else
            {
                //if ai paddle position is greater than the centre point
                //above centre point
                if (this.transform.position.y > 0.0f)
                {
                    //move paddle down
                    _rigidbody.AddForce(Vector2.down * this.speed);
                }
                else if (this.transform.position.y < 0.0f)
                {
                    //moves paddle up
                    _rigidbody.AddForce(Vector2.up * this.speed);
                }


            }
        }
    }
}
