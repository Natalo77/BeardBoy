using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Infinitely spins an object
public class RotateScript : MonoBehaviour
{
    //Attatched to every CD and Energy Drink.

    private float rotateSpeed = (float)3.5;     //How fast the object rotates

    void Update()
    {
        /*
        Spins the object it's attatched to by rotateSpeed.
        */

        transform.Rotate((float)0, (float)0, -rotateSpeed);
	}
}