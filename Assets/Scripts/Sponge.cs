using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Sponge : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public void Interact()
    {
        if (manager.GetComponent<handsScript>().Get() == "nothing")
        {
            manager.GetComponent<handsScript>().Set("sponge");
            gameObject.SetActive(false);
        }

    }
}
