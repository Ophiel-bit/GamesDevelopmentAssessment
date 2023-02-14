using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button overButton;
    void Start()
    {
        overButton.onClick.AddListener(TaskOnClick);//Calls the TaskOnClickmethod when click the Button
    }

    void TaskOnClick()//when button is clicked
    {
        SceneManager.LoadScene("startScreen");//goes to start screen
    }
}
