using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public string keyName = "sink key";
    public GameObject manager;

    public void Interact()
    {
        var hands = manager.GetComponent<handsScript>();
        if (hands == null)
        {
            Debug.LogWarning("KeyPickup: manager has no handsScript!");
            return;
        }

        if (hands.Get() == "nothing" || hands.Get() == "sponge") 
        {
            hands.Set(keyName);
            gameObject.SetActive(false);
            Debug.Log("KeyPickup: picked up key '" + keyName + "'");
        }
        else
        {
            Debug.Log("KeyPickup: your hands are full.");
        }
    }
}

