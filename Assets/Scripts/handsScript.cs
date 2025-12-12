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
    void Update()
    {
        // DEBUG: Press B to instantly hold a burger
        if (Input.GetKeyDown(KeyCode.B))
        {
            Set("burger");
            Debug.Log("DEBUG: Holding burger now");
        }

        // DEBUG: Press C to hold a cheeseburger
        if (Input.GetKeyDown(KeyCode.C))
        {
            Set("cheeseburger");
            Debug.Log("DEBUG: Holding cheeseburger now");
        }
    }
}
