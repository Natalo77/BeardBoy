using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//Allows the player to restart the game
public class RestartScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => taskOnClick());
        Time.timeScale = 1;  //see long comment in endingScript
    }
    void taskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}