using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.XR;

public class TimerManager : MonoBehaviour
{
    private float startTime;
    private float TimeLeft;
    public TextMeshProUGUI txt;
    private handsScript manager;

    void Start()
    { manager = FindAnyObjectByType<handsScript>();}

    void resetTime()
    {
       startTime = Time.time; 
    }
    void Update ()
    {
        if(manager.inTutorial==false){
            TimeLeft = 600f - (Time.time - startTime);
            TimeLeft = Mathf.Clamp(TimeLeft, 0f, 600f);
            int minutes = Mathf.FloorToInt(TimeLeft/60);
            int seconds = Mathf.FloorToInt(TimeLeft%60);

            txt.text = $"Time Left: {minutes:00}:{seconds:00}";
        }else
        {
          txt.text = "";
          resetTime();
        }
}

}