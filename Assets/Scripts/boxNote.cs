using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class boxNote : MonoBehaviour, IInteractable
{
    public GameObject note;
    public GameObject manager;

    public void Interact()
    {
        manager.GetComponent<handsScript>().openNote(note);
    }

}