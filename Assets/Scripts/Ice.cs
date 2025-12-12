using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ice : MonoBehaviour, IInteractable
{
    public GameObject ice;
    public GameObject ice2;
    public GameObject key;
    public GameObject manager;
    TextMeshPro promptText; 
    private int step;

    void Awake()
    {
        var promptTransform = transform.Find("InteractPrompt");
        promptText = promptTransform.GetComponent<TextMeshPro>();
    }

    void Start()
    {
        step = 0;
        key.SetActive(false);
        ice.SetActive(true);
        ice2.SetActive(false);
    }
    public void Interact()
    {
        switch (step)
        {
            case 0:
                if (manager.GetComponent<handsScript>().Get() == "vodka")
                {
                    step+=1;
                    manager.GetComponent<handsScript>().Set("nothing");
                    ice2.SetActive(true);
                    ice.SetActive(false);
                }
                break;
            case 1:
                if(manager.GetComponent<handsScript>().Get() == "match")
                {
                    step+=1;
                    manager.GetComponent<handsScript>().Set("nothing");
                    ice2.SetActive(false);
                    key.SetActive(true);
                }
                break;
            case 2:
                key.SetActive(false);
                //manager.GetComponent<handsScript>().GainKey(3);
                break;
            default: 
                break;
        }
    }

    void Update()
    {
        if (!promptText.gameObject.activeSelf)
        {
            return;
        }  

        if(manager.GetComponent<handsScript>().Get() == "vodka" && step == 0)
        {
            promptText.text= "E - pour vodka";
        }else if(manager.GetComponent<handsScript>().Get() == "match" && step == 1)
        {
            promptText.text= "E - set on fire";
        }else if(step == 2)
        {
            promptText.text= "E - grab key to dungeon";
        }
        else
        {
            promptText.text= "";
        }
    }

}