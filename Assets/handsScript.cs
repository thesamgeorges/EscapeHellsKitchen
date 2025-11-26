using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class handsScript : MonoBehaviour
{
    public TextMeshPro textMesh;
    public string item;
    // Start is called before the first frame update
    void Start()
    {
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Currently holding: " + item;
    }

    public void Set(string item)
    {
        textMesh.text = "Currently holding: " + item;
    }
}
