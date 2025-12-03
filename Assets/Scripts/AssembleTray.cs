using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AssembleTray : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public GameObject cookedPatty;
    public GameObject cheese;
    public GameObject lettuce;
    public GameObject topBun;
    public GameObject buttomBun;
    public GameObject burger;
    public GameObject plate;
    int step;
    bool isCheese;
    TextMeshPro promptText; 

    void Awake()
    {
        var promptTransform = transform.Find("InteractPrompt");
        promptText = promptTransform.GetComponent<TextMeshPro>();
    }
    void Start()
    {
        cookedPatty.SetActive(false);
        cheese.SetActive(false);
        lettuce.SetActive(false);
        topBun.SetActive(false);
        buttomBun.SetActive(false);
        burger.SetActive(false);
        plate.SetActive(false);
        isCheese = false;
        step = 0;
    }

    void Update()
    {
        if (!promptText.gameObject.activeSelf)
        {
            return;
        }  

        if(manager.GetComponent<handsScript>().Get() == "plate" && step == 0)
        {
            promptText.text= "E - place plate";
        }
        else if(manager.GetComponent<handsScript>().Get() == "bun" && step == 1)
        {
            promptText.text= "E - place bun";
        }
        else if(manager.GetComponent<handsScript>().Get() == "cooked patty" && step == 2)
        {
            promptText.text= " E - place burger";
        }
        else if(manager.GetComponent<handsScript>().Get() == "cheese patty" && step == 3)
        {
            promptText.text= " E - place cheeseburger";
        }
        else if(manager.GetComponent<handsScript>().Get() == "lettuce" && step == 4)
        {
            promptText.text = "E - place lettuce";
        }
        else if(manager.GetComponent<handsScript>().Get() == "bun" && step == 5)
        {
            promptText.text = "E - place bun";
        }
        else if(manager.GetComponent<handsScript>().Get() == "nothing" && step == 6)
        {
            if (isCheese == true)
            {
                promptText.text = "E - grab cheeseburger";
            }
            else {promptText.text = "E - grab burger";}
        }
        else if(manager.GetComponent<handsScript>().Get() == "nothing")
        {
            promptText.text = "E - grab unfinished plate";
        }

    }
    public void Interact()
    {
        switch (step)
        {
            case 0:
                if (manager.GetComponent<handsScript>().Get() == "plate")
                {
                    step+=1;
                    manager.GetComponent<handsScript>().Set("nothing");
                    plate.SetActive(false);
                }
                    break;
            case 1: 
                    break;
            default:
                    break;
        }
            
               
    }
}
