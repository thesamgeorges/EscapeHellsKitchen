using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
public class Plates : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public void Interact()
    {
        if (manager.GetComponent<handsScript>().Get()=="nothing"){
            manager.GetComponent<handsScript>().Set("plate");
        }  
    }
}
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plates : MonoBehaviour, IInteractable
{
    public GameObject manager;           // object with handsScript
    public IntroTutorial introTutorial;  // reference to IntroTutorial

    public void Interact()
    {
        if (manager == null)
        {
            Debug.LogWarning("Plates: manager is NOT assigned in the Inspector!");
            return;
        }

        var hands = manager.GetComponent<handsScript>();
        if (hands == null)
        {
            Debug.LogWarning("Plates: manager has NO handsScript component!");
            return;
        }

        Debug.Log("Plates.Interact() called. Hands currently = " + hands.Get());

        if (hands.Get() == "nothing")
        {
            hands.Set("plate");
            Debug.Log("Plates: set hands to 'plate'");

            if (introTutorial != null)
            {
                Debug.Log("Plates: calling introTutorial.OnPlatePickedUp()");
                introTutorial.OnPlatePickedUp();
            }
            else
            {
                Debug.LogWarning("Plates: introTutorial reference is NULL!");
            }
        }
        else
        {
            Debug.Log("Plates: hands not empty, no pickup.");
        }
    }
}


