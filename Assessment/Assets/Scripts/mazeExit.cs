using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mazeExit : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        TriangleController controller = other.GetComponent<TriangleController>();
        if (controller.keys >= 3) //gets how many keys triangle has and checks if there's at least 3
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//if so goes to next scene
        }
    }
}
