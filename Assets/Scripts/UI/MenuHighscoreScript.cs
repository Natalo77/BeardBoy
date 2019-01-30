using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Allows the current highscore to be displayed in the main menu
public class MenuHighscoreScript : MonoBehaviour
{
    void Start()
    {
        /*
        Add the current highscore on the local instance to the end of the highscore text (displayed on screen).
        */

        gameObject.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
        Cursor.visible = true;
    }
}