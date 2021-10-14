using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json.Schema;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class numberControl : MonoBehaviour
{
    public int number;
    public bool divide, plusMinus, multiply;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("playersCol"))
        {
            soundManager.instance.PlayerSpawnSound();

            if(plusMinus == true && number > 0)
            {
                StartCoroutine(FindObjectOfType<GameManager>().RandomSprite());
            }
            else if(multiply == true)
            {
                StartCoroutine(FindObjectOfType<GameManager>().RandomSprite());
            }
            
           

            PlayersControl(number);
        }
    }

   

    public void PlayersControl(int value)
    {
        if(divide == true)
        {
            FindObjectOfType<GameManager>().ActivePlayerControl2(value);
        }
        else if(plusMinus == true)
        {
            FindObjectOfType<GameManager>().ActivePlayerControl(value);
        }
        else if(multiply == true)
        {
            FindObjectOfType<GameManager>().ActivePlayerControl3(value);
        }
        
    }
}
