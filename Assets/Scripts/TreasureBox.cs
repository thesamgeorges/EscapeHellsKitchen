using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TreasureBox : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public GameObject cold;
    public void Interact()
    {
        if (manager.GetComponent<handsScript>().Get()=="nothing"){
            manager.GetComponent<handsScript>().Set("match");
            cold.GetComponent<FrezerCold>().foundMatches=true;
        }
    }
}
