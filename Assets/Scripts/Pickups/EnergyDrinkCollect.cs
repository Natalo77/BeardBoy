using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Allows the player to collect energy drinks, giving them a speed boost and reversing the fading effect
public class EnergyDrinkCollect : MonoBehaviour
{
    public static int energyDrinksCollected = 0;                //How many energy drinks have been collected - Constant over all instances of script

    private float speedIncrease = (float)2.5;                   //How much faster the player gets after collecting an energy drink
    private float moveForceIncrease = (float)1;                 //How much the acceleration of the player will increase by after collecting an energy drink
    private float animationSpeedIncrease = (float)0.25;         //How much faster the player animation gets after collecting an energy drink
    private float fadeValueDecrease = (float)0.5;               //How much the fading effect is decreased by after an energy drink is collected
    private int timeBeforeRespawning = 25;                      //How long it takes for an energy drink to respawn once it's been collected
    private int energyDrinksCollectedBeforeDespawning = 8;      //How many energy drinks can be collected before they start despawning
    private int energyDrinkSpawnOnMultiple = 4;                 //The multiple on which energy drinks will still spawn in after they have begun despawning

    void OnTriggerEnter2D(Collider2D collider)
    {

        /*
        Only triggers when a box collider hits the object, to prevent both colliders of the player (1 circle, 1 box) triggering twice.
        Plays pickup sound.
        Apply increases to maximum speed, acceleration(moveForce) and animation speed.
        Decreases fade, if the new fade value would go below 0, the fade value is set to 0 instead.
        Increment energy drinks collected.
        Disable the game object.
        Call ExeucuteAfterTime with 25 seconds.
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

            energyDrinksCollected++;

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;

            StartCoroutine(ExecuteAfterTime(timeBeforeRespawning));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        /*
        After 25 seconds, if the amount of energy drinks collected is less than 8 or the amount of energy drinks collected is a multiple of 4
            - Re-Enable this energy drink.  
        */

        yield return new WaitForSeconds(time);

        if (energyDrinksCollected < energyDrinksCollectedBeforeDespawning || energyDrinksCollected % energyDrinkSpawnOnMultiple == 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}