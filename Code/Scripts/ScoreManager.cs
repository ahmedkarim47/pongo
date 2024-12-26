using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to acess unity ui elements
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //variable determines what score players need in order to win
    public int scoreToReach;
    //sets player scores to zero
    private int player1Score = 0;
    private int player2Score = 0;

    //makes the pointing system use the texts at the bottom
    public Text player1ScoreText;
    public Text player2ScoreText;

    //function is called whenever p1 scores a goal
    public void Player1Goal()
    {
        //adds 1 to p1 score
        player1Score++;
        //using to string function as p1 score is an interger
        player1ScoreText.text = player1Score.ToString();
        //checks score to decide whether a side won yet or not
        CheckScore();
    }

    //function is called whenever p2 scores a goal
    public void Player2Goal()
    {
        //adds 1 to p2 score
        player2Score++;
        //using to string function as p2 score is an interger
        player2ScoreText.text = player2Score.ToString();
        //checks score to decide whether a side won yet or not
        CheckScore();
    }

    //change scene if certain points is reached
    private void CheckScore()
    {
        //loads p1 winning screen if p1 wins
        if (player1Score == scoreToReach)
        {
            //p1 winning screen
            SceneManager.LoadScene(2);
        }
        //loads p2 winning screen if p2 wins
        if (player2Score == scoreToReach)
        {
            //p2 winning screen
            SceneManager.LoadScene(7);
        }
    }
}
