using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // same instance of class globally 
    
    public static Score instance;

    
    public Text scoreText;

   
    int score = 0;

    // The Awake method is called when the script instance is being loaded.
    
    void Awake() 
    {
        instance = this;   
    }

    
    void Start()
    {
        // Setting the scoreText UI component to show the current score (initially 0) as a string.
        scoreText.text = score.ToString();
    }

    // Public method to increase the player's score.
    // Other scripts (like the snake script) can call this to add points to the score.
    public void AddPoints()
    {
        // Increase the score by 10 points.
        score = score + 10;

        // Update the scoreText UI component to display the new score.
        scoreText.text = score.ToString();
    }

}
