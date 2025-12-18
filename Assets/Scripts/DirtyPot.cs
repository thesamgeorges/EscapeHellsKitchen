using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using UnityEngine;

public class DirtyPot : MonoBehaviour, IInteractable
{
    private handsScript manager;      // object with handsScript
    public GameObject keyObject;    // key hidden under the pot

    void Start()
    {
        manager = FindAnyObjectByType<handsScript>();
    }
    public void Interact()
    {
        var hands = manager.GetComponent<handsScript>();
        if (hands == null)
        {
            Debug.LogWarning("Pot: manager has no handsScript!");
            return;
        }

        string held = hands.Get();
        Debug.Log("Pot.Interact: player is holding '" + held + "'");

        // Only remove pot + reveal key if holding the sponge
        if (held == "sponge")
        {
            Debug.Log("Pot.Interact: sponge detected, removing pot and revealing key.");

            if (keyObject != null)
                keyObject.SetActive(true);
            else
                Debug.LogWarning("Pot: keyObject is not assigned!");

            // Remove the pot 
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Pot.Interact: need sponge to clean/remove the pot.");
        }
    }
}
