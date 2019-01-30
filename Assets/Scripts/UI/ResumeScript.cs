using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Allows the player to resume playing the game
public class ResumeScript : MonoBehaviour
{

    private GameObject[] items;    //An array to store and access all of the pickup items in the game

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => taskOnClick());
        items = GameObject.FindGameObjectsWithTag("Items");
    }

    void taskOnClick()
    {
        Time.timeScale = 1;
        transform.parent.gameObject.GetComponent<CanvasGroup>().alpha = (float)0;
        GameObject.Find("blackPanel").GetComponent<FadeScript>().enabled = true;
        foreach (GameObject item in items)
        {
            item.GetComponent<RotateScript>().enabled = true;
        }
        Cursor.visible = false;
    }
}