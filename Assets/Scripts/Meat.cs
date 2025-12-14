using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public IntroTutorial introTutorial;   // 👈 add this

    public void Interact()
    {
        var hands = manager.GetComponent<handsScript>();
        if (hands == null)
        {
            Debug.LogWarning("Meat: manager has no handsScript!");
            return;
        }

        if (hands.Get() == "nothing")
        {
            hands.Set("raw meat");

            // 🔥 Tell the tutorial we just picked up the raw patty
            if (introTutorial != null)
            {
                introTutorial.OnPattyPickedUp();
            }
            else
            {
                Debug.LogWarning("Meat: introTutorial reference is NULL!");
            }
        }
    }
}
