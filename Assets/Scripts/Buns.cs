using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buns : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public IntroTutorial introTutorial;   // ?? reference to the tutorial

    public void Interact()
    {
        var hands = manager.GetComponent<handsScript>();
        if (hands == null)
        {
            Debug.LogWarning("Buns: manager has no handsScript!");
            return;
        }

        if (hands.Get() == "nothing")
        {
            hands.Set("bun");

            // ?? Notify tutorial that bun was picked up
            if (introTutorial != null)
            {
                introTutorial.OnBunPickedUp();
            }
            else
            {
                Debug.LogWarning("Buns: introTutorial reference is NULL!");
            }
        }
    }
}
