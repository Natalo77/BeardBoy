using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows the player to pause the game
public class PauseScript : MonoBehaviour
{

    private GameObject[] items;    //An array to store and access all of the pickup items in the game

    void Start()
    {
        items = GameObject.FindGameObjectsWithTag("Items");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            GetComponent<CanvasGroup>().alpha = (float)1;
            GameObject.Find("blackPanel").GetComponent<FadeScript>().enabled = false;
            foreach (GameObject item in items)
            {
                item.GetComponent<RotateScript>().enabled = false;
            }
            Cursor.visible = true;
        }
    }
}