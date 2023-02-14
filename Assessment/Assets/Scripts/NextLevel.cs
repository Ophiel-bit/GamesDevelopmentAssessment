using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        TriangleController player = other.GetComponent<TriangleController>();
        if(player != null)//if player is valid and collides
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//go to next scene
        }
    }
}
