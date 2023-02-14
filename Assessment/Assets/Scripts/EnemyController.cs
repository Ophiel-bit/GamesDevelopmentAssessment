using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Animator animator;
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    AudioSource audioSource;
    public bool woman;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)//if timer reaches 0
        {
            direction = -direction;//reverse direction
            timer = changeTime;//resets timer//
        }//means enemy goes back and forth
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)//if enemy goes up and down
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;//moves enemy vertically, multiplies speed by direction
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;//moves enemy horizontally, multiplies speed by direction
        }

        rigidbody2D.MovePosition(position);//updates position
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        TriangleController player = other.gameObject.GetComponent<TriangleController>();

        if (player != null)
        {
            player.ChangeHealth(-1);//calls change health function and passes -1 for the amount
        }//if player touches them then loses health
    }

    public void PlaySound(AudioClip clip)
    {
        if (woman)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
