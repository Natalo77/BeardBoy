using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Allows the player to return to the main menu
public class ToMenuScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => taskOnClick());
    }

    void taskOnClick()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}