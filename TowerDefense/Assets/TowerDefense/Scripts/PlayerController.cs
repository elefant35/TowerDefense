using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //declare variables
    public int score = 0;
    public Text scoreText;
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
        score += scoreChange;
        scoreText.text = score.ToString();
        Debug.Log("Score was changed");
    }
}
