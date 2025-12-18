using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class boxNote : MonoBehaviour, IInteractable
{
    public GameObject note;
    private handsScript manager;

    void Start()
    {
        manager = FindObjectOfType<handsScript>();
    } 
    public void Interact()
    {
        manager.openNote(note);
    }

}