using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class handsScript : MonoBehaviour
{
    public TextMeshPro textMesh;
    private string obj;
    void Start()
    {
        obj = "nothing";
        textMesh.text = "Currently holding: nothing";
    }
    public string Get()
    {
        return obj;
    }

    public void Set(string item)
    {
        obj = item;
        textMesh.text = "Currently holding: " + obj;
    }
}
