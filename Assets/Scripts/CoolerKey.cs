using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolerKey : MonoBehaviour, IInteractable
{
    private handsScript manager;

    void Start()
    {
        manager = FindObjectOfType<handsScript>();
    }
    public void showKey()
    {
       gameObject.SetActive(true);
    }
    public void Interact()
    {
        gameObject.SetActive(false);
        manager.GetComponent<handsScript>().hasCoolerKey=true;
    }
}
