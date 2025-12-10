using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageNote : MonoBehaviour, IInteractable
{
    public GameObject note;

    void Start()
    {
        note.SetActive(false);
    }
    public void Interact()
    {
        note.SetActive(true);
    }
}
