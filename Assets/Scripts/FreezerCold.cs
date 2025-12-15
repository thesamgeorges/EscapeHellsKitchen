using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using TMPro;

public class FrezerCold : MonoBehaviour
{
    public GameObject border;
    private bool active;
    private float TimeLeft;
    private float startTime;
    public bool foundMatches;
    private handsScript manager;
    public TextMeshProUGUI txt;
    public GameObject flame3;
    public GameObject flame2;
    public GameObject flame1;
    private int flames;
    private bool died;
    void Start()
    {
        manager = FindObjectOfType<handsScript>();
        border.SetActive(false);
        active = false;
        foundMatches = false;
        StartCoroutine(Pulse());
        startTime = Time.time;
        flame1.SetActive(true);
        flame2.SetActive(true);
        flame3.SetActive(true);
        flames = 3;
        died = false;
    }

    IEnumerator Pulse()
    {
        yield return new WaitForSeconds(1f);
        if (foundMatches==false){
            if (active == true)
            {
                border.SetActive(false);
                active = false;
            }
            else
            {
                border.SetActive(true);
                active = true;
            }
            StartCoroutine(Pulse());
        }
        else{
            {
                border.SetActive(false);
                active = false;
            }
        }
    }

    void Update()
    {
        if (foundMatches == true)
        {
            border.SetActive(false);
        }
        else
        {
            TimeLeft = 30f - (Time.time - startTime);
            TimeLeft = Mathf.Clamp(TimeLeft, 0f, 600f);
            int minutes = Mathf.FloorToInt(TimeLeft/60);
            int seconds = Mathf.FloorToInt(TimeLeft%60);

            txt.text = $"Time Left: {minutes:00}:{seconds:00}";

            if (TimeLeft <= 20f && flames == 3)
            {
                flame3.SetActive(false);
                flames -=1;
            }
            if(TimeLeft <= 10f && flames == 2)
            {
                flame2.SetActive(false);
                flames -=1;
            }
            if(TimeLeft <= 0 && died == false)
            {
                died = true;
                flame1.SetActive(false);
                flames -= 1;
                manager.GetComponent<handsScript>().removeLife();
                SceneLoader.Instance.LoadKitchenScene();
                SceneLoader.Instance.UnloadScene("CoolerScene");
            }
        }
    }
}
