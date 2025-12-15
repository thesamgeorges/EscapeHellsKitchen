using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buns : MonoBehaviour, IInteractable
{
    private handsScript manager;
    private IntroTutorial tut;
    
    void Start()
    {
        manager = FindObjectOfType<handsScript>();
    }

    public void Interact()
    {
        if (manager.GetComponent<handsScript>().Get()=="nothing"){
            manager.GetComponent<handsScript>().Set("bun");
        }
        if (manager.inTutorial == true)
        {
            tut = FindAnyObjectByType<IntroTutorial>();
            tut.OnBunPickedUp();
        }
    }
}