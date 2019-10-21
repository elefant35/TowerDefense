using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //declare variables
    private int score = 0;
    [SerializeField] private Text scoreText; //ui element for score
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScore(int scoreChange) //adds to score (or subtracts with negative input)
    {
        score += scoreChange; // changes the score variable
        scoreText.text = score.ToString(); // sets the score in the UI
        //Debug.Log("Score changed to "  + score); // disabled but used for debugging to check score
    }

    public int returnScore() //retreives the score
    {
        return score;
    }
}
