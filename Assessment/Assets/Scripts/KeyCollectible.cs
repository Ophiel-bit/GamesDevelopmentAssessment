using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        TriangleController controller = other.GetComponent<TriangleController>();

        if (controller != null)//if player is valid
        {
            if (controller.keys < controller.maxKeys)//as long as max number of keys haven't been reached
            {
                controller.ChangeKeys(1);//calls change keys amount and increases number by one
                Destroy(gameObject);//destroys key
            }
        }
    }//when triangle goes over a  key they pick it up 
}
