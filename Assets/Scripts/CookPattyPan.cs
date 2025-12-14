using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookPattyPan : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public GameObject cookedMeat;
    public GameObject rawMeat;
    public IntroTutorial introTutorial;   

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
            return;

        if (manager.GetComponent<handsScript>().Get() == "raw meat")
        {
            promptText.text = "E - cook";
        }
        else if (manager.GetComponent<handsScript>().Get() == "nothing" && isCooked == true)
        {
            promptText.text = "E - grab patty";
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
        var hands = manager.GetComponent<handsScript>();
        if (hands == null)
        {
            Debug.LogWarning("CookPattyPan: manager has no handsScript!");
            return;
        }

        if (hands.Get() == "raw meat")
        {
            // Put raw meat on pan and start cooking
            hands.Set("nothing");
            rawMeat.SetActive(true);
            StartCoroutine(Cook());
        }
        else if (hands.Get() == "nothing" && isCooked == true)
        {
            // Pick up cooked patty
            hands.Set("cooked patty");
            cookedMeat.SetActive(false);
            isCooked = false;

            // Tell the tutorial the patty is now cooked + picked up
            if (introTutorial != null)
            {
                introTutorial.OnPattyCooked();
            }
            else
            {
                Debug.LogWarning("CookPattyPan: introTutorial reference is NULL!");
            }
        }
    }
}
