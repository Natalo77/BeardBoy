using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Manages the current score and highscore
public class ScoreScript : MonoBehaviour
{
    public static int scoreValue;               //The current score
    public static int highscoreValue = 0;       //The highscore
    public static Text score;                   //The text on the screen containing the score

    void Start()
    {
        /*
        Get the text component of the score canvas.
        Obtain the local instance highscore value from the playerprefs registry location.
        */

        scoreValue = 0;
        score = GetComponent<Text>();
        highscoreValue = PlayerPrefs.GetInt("Highscore");
    }
	
	void Update()
    {
        /*
        If current score is greater than current high score.
            - set the new highscore to the current score.

        Update the score text with the current score and local instance high score.
        */

        if (scoreValue > highscoreValue)
        {
            highscoreValue = scoreValue;
            PlayerPrefs.SetInt("Highscore", highscoreValue);
        }

        score.text = "Score: " + scoreValue + "\nHighscore: " + highscoreValue;

    }
}