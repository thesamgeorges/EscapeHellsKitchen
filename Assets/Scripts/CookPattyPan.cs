using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookPattyPan : MonoBehaviour, IInteractable
{
    public GameObject manager;
    public GameObject cookedMeat;
    public GameObject rawMeat;

    // 🔥 Hook into your tutorial
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

        var hands = manager.GetComponent<handsScript>().Get();

        if (hands == "raw meat")
        {
            promptText.text = "E - cook";
        }
        else if (hands == "nothing" && isCooked)
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
        // simulate cook time
        yield return new WaitForSeconds(10f);

        isCooked = true;
        rawMeat.SetActive(false);
        cookedMeat.SetActive(true);

        // ✅ Tell the tutorial the patty is now cooked
        if (introTutorial != null)
        {
            introTutorial.OnPattyCooked();
        }
    }

    public void Interact()
    {
        var hands = manager.GetComponent<handsScript>();
        if (hands == null)
        {
            Debug.LogWarning("CookPattyPan: manager has no handsScript!");
            return;
        }

        // Start cooking if holding raw meat
        if (hands.Get() == "raw meat")
        {
            hands.Set("nothing");
            rawMeat.SetActive(true);
            StartCoroutine(Cook());
        }
        // Pick up cooked patty when done
        else if (hands.Get() == "nothing" && isCooked)
        {
            hands.Set("cooked patty");
            cookedMeat.SetActive(false);
            isCooked = false;
        }
    }
}
