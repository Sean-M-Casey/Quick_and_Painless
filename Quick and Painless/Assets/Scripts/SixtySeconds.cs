using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SixtySeconds : MonoBehaviour
{
    public Animator timer;
    int timerStore = 60;
    public Text timerDisplay;
    public bool timerPause = false;
    public bool timeRestart = false;
    bool coroutineOn = true;
    void Start()
    {
        StartCoroutine(TimerCountdown());
    }
    private void Update()
    {
        //unpauses timer and world
        if (timerPause == false)
        {
            Time.timeScale = 1;
        }
        //properly restarts the timer coroutine
        if (coroutineOn == false)
        {
            StartCoroutine(TimerCountdown());
            coroutineOn = true;
        }
    }
    //Coroutine for Timer and Countdown
    public IEnumerator TimerCountdown()
    {
        for (int timeLeft = timerStore; timeLeft >= 0; timeLeft--)
        {
            //displays current timeLeft on UI
            timerDisplay.text = timeLeft.ToString();
            yield return new WaitForSeconds(1f);
            //Starts Alert Animation if timer gets below 10
            if (timeLeft <= 10)
            {
                timer.SetTrigger("Alert");
            }
            //pauses timer and world
            if (timerPause == true)
            {
                Time.timeScale = 0;
            }
            //triggers time restart and restarts coroutine
            if (timeRestart == true)
            {
                timerStore = 60;
                timeRestart = false;
                coroutineOn = false;
                StopCoroutine(TimerCountdown());
            }
        }
    }
    public void timePauseTrigger()
    {
        timerPause = true;
    }
    public void timeUnPauseTrigger()
    {
        timerPause = false;
    }
    public void timeRestartTrigger()
    {
        timeRestart = true;
    }
}
