using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public void Interact()
    {
            manager.GetComponent<handsScript>().Set("nothing");    
    }
}
