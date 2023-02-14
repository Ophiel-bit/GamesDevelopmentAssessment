using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetHouse : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)//when triangle enters the box collider
    {
        TriangleController controller = other.GetComponent<TriangleController>();
        if (controller != null)
        {
            if (controller.keys >= 1) //if triangle has at least one key
            {
                controller.ChangeKeys(-1);//take it away from overall amount
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//switch to next scene
            }
        }
    }
}
