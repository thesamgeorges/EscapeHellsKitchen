using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class Sponge : MonoBehaviour, IInteractable
{
    private handsScript manager;

    void Start()
    {
        manager = FindAnyObjectByType<handsScript>();
    }
    public void Interact()
    {
        if (manager.GetComponent<handsScript>().Get() == "nothing")
        {
            manager.GetComponent<handsScript>().Set("sponge");
            gameObject.SetActive(false);
        }

    }
}
