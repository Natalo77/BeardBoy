using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Allows the player to start the game
public class PlayScript : MonoBehaviour
{
	void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Main"));
    }
}