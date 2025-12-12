using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;


public class CookPattyPan : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public GameObject cookedMeat;
    public GameObject rawMeat;
    public GameObject cheese;
    public GameObject burnt;
    public AudioSource source;
    public AudioClip sizzle;
    private bool isCooked;
    private bool isCheese;
    private bool empty;
    private bool isBurnt;
    TextMeshPro promptText;  
    

    void Awake()
    {
        var promptTransform = transform.Find("InteractPrompt");
        promptText = promptTransform.GetComponent<TextMeshPro>();
    }
    void Start()
    {
        rawMeat.SetActive(false);
        cookedMeat.SetActive(false);
        cheese.SetActive(false);
        burnt.SetActive(false);
        isCooked = false;
        empty = true;
        isBurnt = false;
    }
    void Update()
    {
        if (!promptText.gameObject.activeSelf)
        {
            return;
        }  

        if(manager.GetComponent<handsScript>().Get() == "raw meat"&& empty == true)
        {
            promptText.text= "E - cook";
        }
        else if(manager.GetComponent<handsScript>().Get() == "nothing" && isCooked == true)
        {
            promptText.text= " E - grab patty";
        }else if(manager.GetComponent<handsScript>().Get() == "cheese" && isCooked == true)
        {
            promptText.text= " E - place cheese";
        }else if (manager.GetComponent<handsScript>().Get() == "nothing" && isBurnt == true)
        {
            promptText.text = "E = grab burnt patty";
        }
        else
        {
            promptText.text = "Pan has no actions";
        }

    }
    IEnumerator Cook()
    {
        source.PlayOneShot(sizzle);
        yield return new WaitForSeconds(10f);
        isCooked = true;
        rawMeat.SetActive(false);
        cookedMeat.SetActive(true);
        StartCoroutine(SetTimer());
    }

    IEnumerator SetTimer()
    {
        yield return new WaitForSeconds(10f);
        if(empty == false)
        {
            isBurnt = true;
            isCooked = false;
            cookedMeat.SetActive(false);
            burnt.SetActive(true);
            manager.GetComponent<handsScript>().removeLife();
        }
    }
    public void Interact()
    {
       if (manager.GetComponent<handsScript>().Get() == "raw meat"&&empty == true){ // if holding raw meat, cooks patty
            manager.GetComponent<handsScript>().Set("nothing");
            rawMeat.SetActive(true);
            empty = false;
            StartCoroutine(Cook());
       }else if(manager.GetComponent<handsScript>().Get() == "cheese" && isCooked == true){
            cheese.SetActive(true);
            isCheese = true;
            manager.GetComponent<handsScript>().Set("nothing");
        }else if(manager.GetComponent<handsScript>().Get() == "nothing" && isCooked == true){ //if holding nothing and cooked is true, pick up cooked meat
            if (isCheese == true)
            {
                manager.GetComponent<handsScript>().Set("cheese patty");
                cheese.SetActive(false);
            }
            else
            {
                manager.GetComponent<handsScript>().Set("cooked patty");
            }
            cookedMeat.SetActive(false);
            isCooked = false;
            empty = true;
        }else if(manager.GetComponent<handsScript>().Get() == "nothing" && isBurnt == true)
        {
            manager.GetComponent<handsScript>().Set("burnt patty");
            burnt.SetActive(false);
            isBurnt = false;
            cheese.SetActive(false);
            empty = true;
        }
    }
}
