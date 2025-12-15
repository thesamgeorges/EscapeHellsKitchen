using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TreasureBox : MonoBehaviour, IInteractable
{
    private handsScript manager;
    public GameObject cold;
    void Start()
    {
       manager = FindObjectOfType<handsScript>();
    }
    public void Interact()
    {
        if (manager.GetComponent<handsScript>().Get()=="nothing"){
            manager.GetComponent<handsScript>().Set("match");
            cold.GetComponent<FrezerCold>().foundMatches=true;
        }
    }
}
