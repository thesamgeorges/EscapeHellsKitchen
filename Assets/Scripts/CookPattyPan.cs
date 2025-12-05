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
    private bool isCooked;
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
        isCooked = false;
    }
    void Update()
    {
        if (!promptText.gameObject.activeSelf)
        {
            return;
        }  

        if(manager.GetComponent<handsScript>().Get() == "raw meat")
        {
            promptText.text= "E - cook";
        }
        else if(manager.GetComponent<handsScript>().Get() == "nothing" && isCooked == true)
        {
            promptText.text= " E - grab patty";
        }
        else
        {
            promptText.text = "Pan has no actions";
        }

    }
    IEnumerator Cook()
    {
        yield return new WaitForSeconds(10f);
        isCooked = true;
        rawMeat.SetActive(false);
        cookedMeat.SetActive(true);
    }
    public void Interact()
    {
       if (manager.GetComponent<handsScript>().Get() == "raw meat"){ // if holding raw meat, cooks patty
            manager.GetComponent<handsScript>().Set("nothing");
            rawMeat.SetActive(true);
            StartCoroutine(Cook());

       }else if(manager.GetComponent<handsScript>().Get() == "nothing" && isCooked == true){ //if holding nothing and cooked is true, pick up cooked meat
            manager.GetComponent<handsScript>().Set("cooked patty");
            cookedMeat.SetActive(false);
            isCooked = false;
        }     
    }
}
