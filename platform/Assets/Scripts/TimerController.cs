
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timerText;
    private float startTime;

    



    private float elapsedTime;


    private void Start()
    {
        startTime = Time.time;
    }


    void update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = ((int)t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

   

    

  
}
