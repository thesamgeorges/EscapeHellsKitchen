using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; // or TMP; see note below

public class BurgerTutorial : MonoBehaviour
{
    public enum Step
    {
        None,
        GetBun,
        GetPatty,
        CookPatty,
        AssembleBurger,
        DeliverBurger,
        Done
    }

    [Header("UI")]
    // If you use TextMeshPro, change this to TextMeshProUGUI and add "using TMPro;"
    public Text dialogueText;

    [Header("Highlights (optional)")]
    public GameObject highlightBun;
    public GameObject highlightPatty;
    public GameObject highlightGrill;
    public GameObject highlightPlateOrBoard;
    public GameObject highlightServingCounter;

    [Header("Events (optional)")]
    // You can hook these into other systems if needed
    public UnityEvent OnTutorialFinished;

    private Step currentStep = Step.None;

    void Start()
    {
        // Don’t start automatically; we’ll call StartTutorial() after Gordon speaks.
        SetAllHighlights(false);
    }

    void SetAllHighlights(bool value)
    {
        if (highlightBun) highlightBun.SetActive(false);
        if (highlightPatty) highlightPatty.SetActive(false);
        if (highlightGrill) highlightGrill.SetActive(false);
        if (highlightPlateOrBoard) highlightPlateOrBoard.SetActive(false);
        if (highlightServingCounter) highlightServingCounter.SetActive(false);
    }

    void ShowStep(Step step)
    {
        SetAllHighlights(false);

        switch (step)
        {
            case Step.GetBun:
                if (dialogueText)
                    dialogueText.text = "First, grab a bun from the bun station.";
                if (highlightBun)
                    highlightBun.SetActive(true);
                break;

            case Step.GetPatty:
                if (dialogueText)
                    dialogueText.text = "Good. Now pick up a raw patty.";
                if (highlightPatty)
                    highlightPatty.SetActive(true);
                break;

            case Step.CookPatty:
                if (dialogueText)
                    dialogueText.text = "Take that patty to the grill and cook it.";
                if (highlightGrill)
                    highlightGrill.SetActive(true);
                break;

            case Step.AssembleBurger:
                if (dialogueText)
                    dialogueText.text = "Nice sizzle. Put the cooked patty on the bun to assemble the burger.";
                if (highlightPlateOrBoard)
                    highlightPlateOrBoard.SetActive(true);
                break;

            case Step.DeliverBurger:
                if (dialogueText)
                    dialogueText.text = "Now take the burger to the serving counter.";
                if (highlightServingCounter)
                    highlightServingCounter.SetActive(true);
                break;

            case Step.Done:
                if (dialogueText)
                    dialogueText.text = "That’s it. You’ve got the basics. Now cook for real customers.";
                SetAllHighlights(false);
                OnTutorialFinished?.Invoke();
                break;
        }
    }

    // Called from Gordon’s script once he is done talking.
    public void StartTutorial()
    {
        currentStep = Step.GetBun;
        ShowStep(currentStep);
    }

    // The following are called by your interaction / cooking scripts
    // when the player completes each action.

    public void OnPickedUpBun()
    {
        if (currentStep != Step.GetBun) return;
        currentStep = Step.GetPatty;
        ShowStep(currentStep);
    }

    public void OnPickedUpPatty()
    {
        if (currentStep != Step.GetPatty) return;
        currentStep = Step.CookPatty;
        ShowStep(currentStep);
    }

    public void OnPattyCooked()
    {
        if (currentStep != Step.CookPatty) return;
        currentStep = Step.AssembleBurger;
        ShowStep(currentStep);
    }

    public void OnBurgerAssembled()
    {
        if (currentStep != Step.AssembleBurger) return;
        currentStep = Step.DeliverBurger;
        ShowStep(currentStep);
    }

    public void OnBurgerDelivered()
    {
        if (currentStep != Step.DeliverBurger) return;
        currentStep = Step.Done;
        ShowStep(currentStep);
    }

    public void OnPickedUpPlate()
    {
        if (currentStep != Step.None) return;

        // Move to the first real tutorial step (GetBun)
        currentStep = Step.GetBun;
        ShowStep(currentStep);
    }

}

