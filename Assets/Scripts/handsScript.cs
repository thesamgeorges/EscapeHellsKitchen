using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class handsScript : MonoBehaviour
{
    public TextMeshPro textMesh;
    private string obj;
    private int day;
    void Start()
    {
        obj = "nothing";
        day = 0;
        textMesh.text = "Currently holding: nothing";
    }
    public string Get()
    {
        return obj;
    }

    public int GetDay()
    {
        return day;
    }
    public void IncreaseDay(){
        day+=1;
    }
    public void Set(string item)
    {
        obj = item;
        textMesh.text = "Currently holding: " + obj;
    }
}
