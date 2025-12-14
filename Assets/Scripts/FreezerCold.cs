using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class FrezerCold : MonoBehaviour
{
    public GameObject border;
    private bool active;
    public bool foundMatches;
    public GameObject manager;
    void Start()
    {
        border.SetActive(false);
        active = false;
        foundMatches = false;
        StartCoroutine(Pulse());
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(300f);
        if(foundMatches!=true){
            kill();
        }
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
    void kill()
    {
        manager.GetComponent<handsScript>().removeLife();
        SceneManager.LoadScene("Kitchen Scene");
    }

    void Update()
    {
        if (foundMatches == true)
        {
            border.SetActive(false);
        }
    }
}
