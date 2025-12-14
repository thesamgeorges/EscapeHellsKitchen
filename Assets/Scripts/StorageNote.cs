using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageNote : MonoBehaviour, IInteractable
{
    public GameObject note;
    public GameObject manager;
    public void Interact()
    {
        manager.GetComponent<handsScript>().openNote(note);
    }
}
