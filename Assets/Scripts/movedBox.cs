using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movedBox : MonoBehaviour, IInteractable
{
    public GameObject box;
    public GameObject manager;
    private bool isMoved;

    void Start()
    {
     isMoved = false;
     box.transform.position = new Vector3(6.33f, -0.41f, -2.71f);
    }
    public void Interact()
    {
        if(isMoved == false){
            box.transform.position = new Vector3(5.878472f, -0.8403551f, -2.587066f);
            isMoved = true;
        }
        else
        {
            box.transform.position = new Vector3(6.33f, -0.41f, -2.71f);
            isMoved = false;
        }
        
    }

}