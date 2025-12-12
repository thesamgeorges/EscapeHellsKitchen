using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFridgeDoors : MonoBehaviour, IInteractable
{

    public GameObject door1;
    public GameObject door2;
    bool isOpen;

    void Start()
    {
        isOpen = false;
        door1.transform.rotation = Quaternion.Euler(0f, 90, 0f);
        door2.transform.rotation = Quaternion.Euler(0f, 180, 0f);
    }

    public void Interact()
    {
        if (isOpen)
        {
            door1.transform.rotation = Quaternion.Euler(0f, 380, 0f);
            door2.transform.rotation = Quaternion.Euler(0f, 300, 0f);
            isOpen = false;
        }
        else
        {
            door1.transform.rotation = Quaternion.Euler(0f, 180, 0f);
            door2.transform.rotation = Quaternion.Euler(0f, 180, 0f);
            isOpen = true;
        }
    }
}
