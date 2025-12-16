using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SinkKey : MonoBehaviour, IInteractable
{
    private handsScript hands;

    void Start(){
        hands = FindAnyObjectByType<handsScript>();
    }
    public void Interact()
    {
        gameObject.SetActive(false);
        hands.hasStorageKey=true;
        if (hands.Get() == "sponge") 
        {
            hands.Set("nothing");
        }
    }
}

