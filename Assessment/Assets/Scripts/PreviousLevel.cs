using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        TriangleController player = other.GetComponent<TriangleController>();
        if (player != null)//if player is valid and collides with the box collider
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //returns to previous scene
        }
    }
}
