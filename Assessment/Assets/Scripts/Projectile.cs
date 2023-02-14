using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public char axis;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);//launches projectile
        Invoke("timeDelete", 10.0f);//invokes (waits for time specified in second parameter until calling the function) time delete
    }

    void Update()
    {
        if (transform.position.magnitude > 1000.0f)//if there's over a certain amount
        {
            Destroy(gameObject);//destroy it
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        SoldierController soldier = other.collider.GetComponent<SoldierController>();
        if (soldier != null)//if soldier valid
        {
            soldier.disguise();//calls soldier disguise function
        }//when soldier is hit causes them to move
        Destroy(gameObject);//destroy upon contact
    }

    void timeDelete()
    {
        Destroy(gameObject);//destroys projectile after a certain amount of time
    }

}
