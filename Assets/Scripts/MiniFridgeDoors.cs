using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniFridgeDoors : MonoBehaviour, IInteractable
{

    public GameObject door1;
    public GameObject door2;
    bool isOpen;
    private handsScript manager;

    public TextMeshPro promptText; 

    void Start()
    {
        manager =  FindObjectOfType<handsScript>();
        isOpen = false;
        door1.transform.rotation = Quaternion.Euler(0f, 90, 0f);
        door2.transform.rotation = Quaternion.Euler(0f, 90, 0f);
    }
     void Awake()
    {
        var promptTransform = transform.Find("InteractPrompt");
        promptText = promptTransform.GetComponent<TextMeshPro>();
    }
    public void Interact()
    {
        if(manager.hasDungeonKey == true && isOpen == false){

            door1.transform.rotation = Quaternion.Euler(0f, 180, 0f);
            door2.transform.rotation = Quaternion.Euler(0f, 45, 0f);
            isOpen = true;   
        }else if(isOpen == true)
        {
            SceneLoader.Instance.LoadCageScene();
            SceneLoader.Instance.UnloadScene("StorageScene");
        }
    }

    public void Update()
    {
        if (!promptText.gameObject.activeSelf)
        {
            return;
        }  

        if(manager.hasDungeonKey == true && isOpen == false)
        {
            promptText.text= "E - open door";
        }else if(manager.hasDungeonKey == true && isOpen == true)
        {
            promptText.text= "E - go inside";
        }
        else
        {
            promptText.text= "cannot interact";
        }
    }
}
