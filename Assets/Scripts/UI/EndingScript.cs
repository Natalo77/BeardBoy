using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ends the game when the screen has fully faded to black
public class EndingScript : MonoBehaviour
{
    public Rigidbody2D player;

    private static GameObject pauseText;

    private CanvasGroup canvas;

    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        pauseText = GameObject.Find("pauseText");
    }

    void Update()
    {
        if (FadeScript.fadeValue == (float)1)
        {
            canvas.alpha = (float)1;  //There was a load of code here that Luke knows about that we removed because he added that little line below that does everything all the big code did
            Time.timeScale = 0;
            if (pauseText.activeSelf == true)
            {
                pauseText.SetActive(false);
            }
            Cursor.visible = true;
        }
    }
}