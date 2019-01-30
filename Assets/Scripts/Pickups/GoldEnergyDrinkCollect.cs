using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows the player to collect gold energy drinks, giving them a speed boost and reversing the fading effect
public class GoldEnergyDrinkCollect : MonoBehaviour
{
    public static int energyDrinksCollected = 0;            //How many gold energy drinks have been collected

    private float speedIncrease = (float)3.5;               //How much faster the player gets after collecting a gold energy drink
    private float moveForceIncrease = (float)2;             //How much the acceleration of the player will increase by after collecting a gold energy drink
    private float animationSpeedIncrease = (float)0.35;     //How much faster the player animation gets after collecting a gold energy drink
    private float fadeValueDecrease = (float)0.75;          //How much the fading effect is decreased by after a gold energy drink is collected

    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        StartCoroutine(ExecuteAfterTime(RandomNumberScript.RandomNumber()));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        /*
        Only triggers when a box collider hits the object, to prevent both colliders of the player (1 circle, 1 box) triggering twice.
        Plays pickup sound.
        Apply increases to maximum speed, acceleration(moveForce) and animation speed.
        Decreases fade, if the new fade value would go below 0, the fade value is set to 0 instead.
        Increment energy drinks collected.
        Disable the game object.
        Call ExeucuteAfterTime with a random time.
        */

        if (collider is BoxCollider2D)
        {
            GameObject.FindWithTag("soundManager").GetComponents<AudioSource>()[1].Play();

            CustomPlayerController.maxSpeed += speedIncrease;
            CustomPlayerController.moveForce += moveForceIncrease;
            CustomPlayerController.animationSpeed += animationSpeedIncrease;

            if (FadeScript.fadeValue >= fadeValueDecrease)
            {
                FadeScript.fadeValue -= fadeValueDecrease;
            }
            else if (FadeScript.fadeValue < fadeValueDecrease)
            {
                FadeScript.fadeValue = (float)0;

            }
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;

            StartCoroutine(ExecuteAfterTime(RandomNumberScript.RandomNumber()));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        /*
        After a random time between 100 and 299 seconds.
            - Re-Enable this energy drink.  
        */

        yield return new WaitForSeconds(time);

        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
    }
}