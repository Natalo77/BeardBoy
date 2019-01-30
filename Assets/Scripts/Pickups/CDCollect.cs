using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows the player to collect CDs and adds them to their score
public class CDCollect : MonoBehaviour
{
    private int CDValue = 1;                    //How many points the player receives for each CD they collect
    private int timeBeforeRespawning = 25;      //How long it takes for a CD to respawn once it's been collected

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider is BoxCollider2D)
        {
            GameObject.FindWithTag("soundManager").GetComponents<AudioSource>()[0].Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            ScoreScript.scoreValue += CDValue;
            StartCoroutine(ExecuteAfterTime(timeBeforeRespawning));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}