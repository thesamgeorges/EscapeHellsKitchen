using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour, IInteractable
{
    private handsScript manager;
    void Start()
    {
        manager = FindObjectOfType<handsScript>();
    }
    public void Interact()
    {
            manager.GetComponent<handsScript>().Set("nothing");  
    }
}
