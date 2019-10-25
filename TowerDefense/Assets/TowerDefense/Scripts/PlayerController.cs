using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //declare variables
    private int score = 0;
    [SerializeField] private int StartingScore = 100;
    [SerializeField] private Text scoreText; //ui element for score

    // Start is called before the first frame update
    void Start()
    {
        score = StartingScore;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int scoreChange) //adds to score, do not use for subtraction
    {
        score += scoreChange; // changes the score variable
        scoreText.text = score.ToString(); // sets the score in the UI
        //Debug.Log("Score changed to "  + score); // disabled but used for debugging to check score
    }

    public bool subtractScore( int scoreChange) //subtracts from score, honestly I should probably swap addscore out with this
    {
        if(score - scoreChange >= 0)
        {
            score -= scoreChange;
            scoreText.text = score.ToString();
            return true;
        }
        return false;
        
    }

    public int returnScore() //retreives the score
    {
        return score;
    }
}
