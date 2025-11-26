using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class meat : MonoBehaviour, IInteractable
{
    public GameObject manager;
    // Start is called before the first frame update
    public void Interact()
    {
       manager.GetComponent<handsScript>().Set("meat");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
