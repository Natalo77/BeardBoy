using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows the player to collect gold CDs and adds them to their score
public class GoldCDCollect : MonoBehaviour
{
    private int goldCDValue = 5;        //How many points the player receives for each gold CD they collect

    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        StartCoroutine(ExecuteAfterTime(RandomNumberScript.RandomNumber()));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider is BoxCollider2D)
        {
            GameObject.FindWithTag("soundManager").GetComponents<AudioSource>()[0].Play();
            ScoreScript.scoreValue += goldCDValue;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            StartCoroutine(ExecuteAfterTime(RandomNumberScript.RandomNumber()));
        }
    }

    IEnumerator ExecuteAfterTime(int time)
    {
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}