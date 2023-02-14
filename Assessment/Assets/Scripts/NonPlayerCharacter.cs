using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;

    void Start()
    {
        dialogBox.SetActive(false);//means the dialogue box isn't visible
        timerDisplay = -1.0f;//ensures it doesn't show
    }


    void Update()
    {
        if (timerDisplay >= 0) //if true then dialogue is being displayed
        {
            timerDisplay -= Time.deltaTime;//starts the countdown
            if (timerDisplay < 0)//when is finished
            {
                dialogBox.SetActive(false);//turns off dialogue box again
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;//starts the timer
        dialogBox.SetActive(true);//shows dialogue box
    }
}
