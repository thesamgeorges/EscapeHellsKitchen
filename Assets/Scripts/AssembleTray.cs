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
    public GameObject bottomBun;
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
        erase();
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
        }else if(manager.GetComponent<handsScript>().Get() == "nothing" && step == 0)
        {
            promptText.text= "tray has no actions, needs plate";
        }
        else if(manager.GetComponent<handsScript>().Get() == "bun" && step == 1)
        {
            promptText.text= "E - place bun";
        }
        else if(manager.GetComponent<handsScript>().Get() == "cooked patty" && step == 2)
        {
            promptText.text= " E - place burger";
        }
        else if(manager.GetComponent<handsScript>().Get() == "cheese patty" && step == 2)
        {
            promptText.text= " E - place cheeseburger";
        }
        else if(manager.GetComponent<handsScript>().Get() == "lettuce" && step == 3)
        {
            promptText.text = "E - place lettuce";
        }
        else if(manager.GetComponent<handsScript>().Get() == "bun" && step == 4)
        {
            promptText.text = "E - place bun";
        }
        else if(manager.GetComponent<handsScript>().Get() == "nothing" && step == 5)
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
        else
        {
            promptText.text= "tray currently has no actions";
        }
    }
    public void erase()
    {
        cookedPatty.SetActive(false);
        cheese.SetActive(false);
        lettuce.SetActive(false);
        topBun.SetActive(false);
        bottomBun.SetActive(false);
        plate.SetActive(false);
        isCheese = false;
        step = 0;
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
                    plate.SetActive(true);
                }
                break;
            case 1: 
                if (manager.GetComponent<handsScript>().Get() == "bun")
                {
                    step+=1;
                    manager.GetComponent<handsScript>().Set("nothing");
                    bottomBun.SetActive(true);
                }else if(manager.GetComponent<handsScript>().Get() == "nothing")
                {
                    erase();
                    manager.GetComponent<handsScript>().Set("unfinished burger");
                }
                break;
            case 2: 
                if (manager.GetComponent<handsScript>().Get() == "cooked patty")
                {
                    step+=1;
                    manager.GetComponent<handsScript>().Set("nothing");
                    cookedPatty.SetActive(true);
                }else if (manager.GetComponent<handsScript>().Get() == "cheese patty")
                {
                    step+=1;
                    manager.GetComponent<handsScript>().Set("nothing");
                    cookedPatty.SetActive(true);
                    cheese.SetActive(true);
                    isCheese=true;
                }else if(manager.GetComponent<handsScript>().Get() == "nothing")
                {
                    erase();
                    manager.GetComponent<handsScript>().Set("unfinished burger");
                }
                break;
            case 3: 
                if (manager.GetComponent<handsScript>().Get() == "lettuce")
                {
                    step+=1;
                    manager.GetComponent<handsScript>().Set("nothing");
                    lettuce.SetActive(true);
                }else if(manager.GetComponent<handsScript>().Get() == "nothing")
                {
                    erase();
                    manager.GetComponent<handsScript>().Set("unfinished burger");
                }
                break;
            case 4: 
                if (manager.GetComponent<handsScript>().Get() == "bun")
                {
                    step+=1;
                    manager.GetComponent<handsScript>().Set("nothing");
                    topBun.SetActive(true);
                }else if(manager.GetComponent<handsScript>().Get() == "nothing")
                {
                    erase();
                    manager.GetComponent<handsScript>().Set("unfinished burger");
                }
                break;
            case 5: 
                if (manager.GetComponent<handsScript>().Get() == "nothing")
                {
                    step=0;
                    if(isCheese==true){
                        manager.GetComponent<handsScript>().Set("cheeseburger");                       
                    }
                    else
                    {
                        manager.GetComponent<handsScript>().Set("burger");
                    }
                    erase();
                }else if(manager.GetComponent<handsScript>().Get() == "nothing")
                {
                    erase();
                    manager.GetComponent<handsScript>().Set("unfinished burger");
                }
                break;
            default:
                break;
        }
            
               
    }
}
