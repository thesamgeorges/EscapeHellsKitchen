
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEngine;

public class fridge : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public GameObject door;
    bool isOpen;

    void Start()
    {
        door.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        isOpen = false;
    }
    public void Interact()
    {
        if (isOpen)
        {
            door.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            isOpen = false;
        }
        else
        {
            door.transform.rotation = Quaternion.Euler(0f, 300f, 0f);
            isOpen = true;
        }
    }
}