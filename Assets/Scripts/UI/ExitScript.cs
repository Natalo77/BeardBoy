using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Allows the player to exit the game
public class ExitScript : MonoBehaviour
{
	void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => Application.Quit());
    }
}