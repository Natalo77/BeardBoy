using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

//Generates a random number (used to spawn the gold cds and gold energy drinks at random times)
public class RandomNumberScript : MonoBehaviour
{
    

	public static int RandomNumber()
    {
        /*
        Create a byte array of length 1 - The number range is 000 to 255 - IMPORTANT: 3 Characters long.
        Create a placeholder string randomNumberString.
        Use an RNGCryptoService to get a random byte number and place it in the array.
        Obtain the last digit of the created number.
        If the last digit = 0.
            - Set randomNumberString to 2.
        else if the random number is greater than 2.
            - check if it's odd or even.
            - if odd then set rNS to 1.
            - if even then set rNS to 2.
        rNS is now the first digit of the random number from 0 - 255

        Twice.
            - create a random byte number.
            - modulus the random number by 10 to obtain a value from 0 to 9
                - convert it to a string
                - add this to the end of the random number
    
        Return the random number between 100 and 299
        */

        byte[] byteArray = new byte[1];
        String randomNumberString = "";

        (new RNGCryptoServiceProvider()).GetBytes(byteArray);

        randomNumberString += byteArray[0].ToString()[byteArray[0].ToString().Length - 1];

        if (int.Parse(randomNumberString) == 0)
        {
            randomNumberString = "2";
        }
        else if (int.Parse(randomNumberString) > 2)
        {
            if (int.Parse(randomNumberString) % 2 != 0)
            {
                randomNumberString = "1";
            }
            else if (int.Parse(randomNumberString) % 2 == 0)
            {
                randomNumberString = "2";
            }
        }

        for (int i = 0; i < 2; ++i)
        {
            (new RNGCryptoServiceProvider()).GetBytes(byteArray);
            randomNumberString += (byteArray[0] % 10).ToString();
        }

        return int.Parse(randomNumberString);
    }
}