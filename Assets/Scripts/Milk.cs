using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Milk : MonoBehaviour, IInteractable
{
    public int milkIndex;
    private handsScript manager;
    public GameObject milk;

    void Start()
    {
        if (PersistentObjects.Instance.milkActive[milkIndex])
        {
            milk.SetActive(true);
        }
        else
        {
            milk.SetActive(false);
        }
        manager = FindObjectOfType<handsScript>();
    }
    public void Interact()
    {
        if (manager.GetComponent<handsScript>().Get()=="nothing"){
            manager.GetComponent<handsScript>().Set("milk");
            milk.SetActive(false);
            PersistentObjects.Instance.milkActive[milkIndex] = false;
        }  
    }
}