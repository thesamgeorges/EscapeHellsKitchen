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
    public IntroTutorial introTutorial;

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
            return;

        var hands = manager.GetComponent<handsScript>().Get();

        if (hands == "plate" && step == 0)
        {
            promptText.text = "E - place plate";
        }
        else if (hands == "nothing" && step == 0)
        {
            promptText.text = "tray has no actions, needs plate";
        }
        else if (hands == "bun" && step == 1)
        {
            promptText.text = "E - place bun";
        }
        else if (hands == "cooked patty" && step == 2)
        {
            promptText.text = "E - place burger";
        }
        else if (hands == "cheese patty" && step == 2)
        {
            promptText.text = "E - place cheeseburger";
        }
        else if (hands == "lettuce" && step == 3)
        {
            promptText.text = "E - place lettuce";
        }
        else if (hands == "bun" && step == 4)
        {
            promptText.text = "E - place top bun";
        }
        else if (hands == "nothing" && step == 5)
        {
            promptText.text = isCheese ? "E - grab cheeseburger" : "E - grab burger";
        }
        else if (hands == "nothing")
        {
            promptText.text = "E - grab unfinished plate";
        }
        else
        {
            promptText.text = "tray currently has no actions";
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
        var hands = manager.GetComponent<handsScript>();

        switch (step)
        {
            case 0:
                // Place plate
                if (hands.Get() == "plate")
                {
                    step += 1;
                    hands.Set("nothing");
                    plate.SetActive(true);

                    if (introTutorial != null)
                        introTutorial.OnPlatePlacedOnTray();
                }
                break;

            case 1:
                // Place bottom bun
                if (hands.Get() == "bun")
                {
                    step += 1;
                    hands.Set("nothing");
                    bottomBun.SetActive(true);

                    if (introTutorial != null)
                        introTutorial.OnFirstBunPlaced();
                }
                else if (hands.Get() == "nothing")
                {
                    erase();
                    hands.Set("unfinished burger");
                }
                break;

            case 2:
                // Place cooked patty or cheese patty
                if (hands.Get() == "cooked patty")
                {
                    step += 1;
                    hands.Set("nothing");
                    cookedPatty.SetActive(true);
                    isCheese = false;

                    if (introTutorial != null)
                        introTutorial.OnBurgerAssembled();
                }
                else if (hands.Get() == "cheese patty")
                {
                    step += 1;
                    hands.Set("nothing");
                    cookedPatty.SetActive(true);
                    cheese.SetActive(true);
                    isCheese=true;
                }else if(manager.GetComponent<handsScript>().Get() == "nothing")
                {
                    erase();
                    hands.Set("unfinished burger");
                }
                break;

            case 3:
                // Place lettuce
                if (hands.Get() == "lettuce")
                {
                    step += 1;
                    hands.Set("nothing");
                    lettuce.SetActive(true);

                    if (introTutorial != null)
                        introTutorial.OnLettucePlaced();
                }
                else if (hands.Get() == "nothing")
                {
                    erase();
                    hands.Set("unfinished burger");
                }
                break;

            case 4:
                // Place top bun
                if (hands.Get() == "bun")
                {
                    step += 1;
                    hands.Set("nothing");
                    topBun.SetActive(true);

                    if (introTutorial != null)
                        introTutorial.OnTopBunPlaced();
                }
                else if (hands.Get() == "nothing")
                {
                    erase();
                    hands.Set("unfinished burger");
                }
                break;

            case 5:
                // Finished burger: pick it up
                if (hands.Get() == "nothing")
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
        }
    }
}
