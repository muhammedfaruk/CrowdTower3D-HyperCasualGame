using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleCollisionControl : MonoBehaviour
{
    int diamond;
    int value;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            

            GameObject newParticle = Instantiate(Resources.Load("hitcrystal") as GameObject, other.gameObject.transform.position, Quaternion.identity);
            Destroy(newParticle, 1);

            other.gameObject.SetActive(false);
            GameManager.playerNumber--;

            soundManager.instance.PlayerSound();
        }
       

    }
   


    void LastPointControl()
    {
        value++;
        Debug.Log(value);

    }

   
}
