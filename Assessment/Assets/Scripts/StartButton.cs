using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button goButton;
    void Start()
    {
        goButton.onClick.AddListener(TaskOnClick);//Calls the TaskOnClickmethod when click the Button
    }

    void TaskOnClick()//when button is clicked
    {
        SceneManager.LoadScene("StartScene");//goes to first playable screen
    }
}
