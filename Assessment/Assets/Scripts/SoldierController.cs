using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoldierController : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    public bool vertical;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        TriangleController player = other.gameObject.GetComponent<TriangleController>();

        if (player != null)//if player is valid
        {
            player.ChangeHealth(-1);//calls change health function and passes -1 for the amount
        }//if touches player than makes player lose health
    }

    public void disguise()//this is the function to move soldiers out the way so triangle can pass through
    {
        if (vertical)
        {
            transform.Translate(0, Time.deltaTime * 350, 0, Camera.main.transform);
            //moves soldier vertically up by 350 units relative to the camera positions
        }
        else
        {
            transform.Translate(Time.deltaTime * 350, 0, 0, Camera.main.transform);
            //moves soldier right by 350 units relative to the camera positions
        }
    }
}