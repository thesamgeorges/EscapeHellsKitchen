using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Plates : MonoBehaviour, IInteractable
{
    private handsScript manager;
    private IntroTutorial introTutorial;
    void Start()
    {
        manager = FindObjectOfType<handsScript>();
    }
    public void Interact()
    {
        if(manager.inTutorial == true)
        {
             introTutorial = FindAnyObjectByType<IntroTutorial>();
             introTutorial.OnPlatePickedUp();
        }
        if (manager.GetComponent<handsScript>().Get()=="nothing"){
            manager.GetComponent<handsScript>().Set("plate");
        }  
    }
}