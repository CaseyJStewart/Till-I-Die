using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public Text timerText;

    private float startTime;
    private bool Finished = false;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Finished)
        {
            return;
        }

        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = ((t % 60).ToString("f1"));

        timerText.text = minutes + ":" + seconds;
    }

    public void Finish()
    {
        timerText.color = Color.red;
    }
}
