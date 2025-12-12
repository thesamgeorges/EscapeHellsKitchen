using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class handsScript : MonoBehaviour
{
    public TextMeshPro textMesh;
    private string obj;
    private bool isNoteOpen;
    private GameObject note;
    void Start()
    {
        obj = "nothing";
        textMesh.text = "Currently holding: nothing";
    }
    public string Get()
    {
        return obj;
    }
    public void openNote(GameObject notes)
    {
        note = notes;
        note.SetActive(true);
        isNoteOpen = true;
    }

    void Update()
    {
        if (isNoteOpen && Input.GetKeyDown(KeyCode.E))
        {
            note.SetActive(false);
            isNoteOpen = false;
            note = null;
        }
    }

    public void Set(string item)
    {
        obj = item;
        textMesh.text = "Currently holding: " + obj;
    }
}
