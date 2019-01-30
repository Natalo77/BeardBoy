using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Fades the screen to black over a set period of time
public class FadeScript : MonoBehaviour
{
    public static float fadeValue;                      //How much the screen has already faded by
    public static float fadeSpeed = (float)0.001;       //How fast the fading effect is
    public static float fallIncrement;                  //A counter for fall damage applied by FallFadeScript

    private CanvasGroup canvas;

    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        fadeValue = (float)0;
        fallIncrement = (float)0;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        if (fadeValue + fadeSpeed + fallIncrement < (float)1)
        {
            fadeValue += fadeSpeed;
        }
        else if (fadeValue + fadeSpeed + fallIncrement >= (float)1)
        {
            fadeValue = (float)1;
        }
        canvas.alpha = fadeValue + fallIncrement;
    }
}