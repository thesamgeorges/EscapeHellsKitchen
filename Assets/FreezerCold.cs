using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrezerCold : MonoBehaviour
{
    public GameObject border;
    private bool active;
    private bool foundMatches;

    void Start()
    {
        border.SetActive(false);
        active = false;
        foundMatches = false;
        StartTimer();
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(30f);
        if(foundMatches!=true){
            kill();
        }
    }

    void kill()
    {
        SceneManager.LoadScene("Kitchen Scene");
    }

    void Update()
    {
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
        }
    }
}
