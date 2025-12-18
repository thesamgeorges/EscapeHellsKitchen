using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timerManagerOrder : MonoBehaviour
{
    private float startTime;
    private float TimeLeft;
    public TextMeshProUGUI txt;
    public GameObject manager;
    public GameObject orderManager;
    public GameObject gordon;
    void Start()
    {
        ResetTime();
    }
    public void ResetTime()
    {
        startTime = Time.time;
    }
    void Update ()
    {
        TimeLeft = 300f - (Time.time - startTime);
        TimeLeft = Mathf.Clamp(TimeLeft, 0f, 600f);
        int minutes = Mathf.FloorToInt(TimeLeft/60);
        int seconds = Mathf.FloorToInt(TimeLeft%60);

        txt.text = $"Time Left: {minutes:00}:{seconds:00}";

        if (TimeLeft == 0)
        {
            manager.GetComponent<handsScript>().removeLife();
            orderManager.GetComponent<OrderManager>().CompleteOrder();
            gordon.GetComponent<GordonJumpscares>().scare();
        }
    }
}