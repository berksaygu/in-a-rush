using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = false;
    float t;
    string minutes;
    string seconds;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            timerText.text=minutes + ": " + seconds;
        }
        else
        {
            t = Time.time - startTime;
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
        }
        }
    private void Finish()
    {
        finished = true;
        timerText.color = Color.yellow;
    }
}