using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Milk : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public GameObject milk;

    void Start()
    {
        milk.SetActive(true);
    }
    public void Interact()
    {
        if (manager.GetComponent<handsScript>().Get()=="nothing"){
            manager.GetComponent<handsScript>().Set("milk");
            milk.SetActive(false);
        }  
    }
}