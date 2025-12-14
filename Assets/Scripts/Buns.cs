using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buns : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public IntroTutorial introTutorial;   // reference to the tutorial

    public void Interact()
    {
        var hands = manager.GetComponent<handsScript>();
        if (hands == null)
        {
            Debug.LogWarning("Buns: manager has no handsScript!");
            return;
        }

        string before = hands.Get();
        Debug.Log("Buns.Interact: was holding '" + before + "', now giving 'bun'");

        // ✅ Always give a bun, no matter what we were holding
        hands.Set("bun");

        // Let the tutorial know a bun was picked up.
        // IntroTutorial ignores this unless currentStep == GetBun.
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
