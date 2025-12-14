using UnityEngine;
using TMPro;

public class IntroTutorial : MonoBehaviour
{
    public enum TutorialStep
    {
        None,
        GetPlate,
        PlacePlate,   
        GetBun,
        PlaceFirstBun,
        GetPatty,
        PlaceRawMeatOnPan,
        CookPatty,
        AddLettuce,
        AddTopBun,
        AssembleBurger,
        DeliverBurger,
        Complete
    }

    [Header("Gordon Dialogue UI")]
    public GameObject dialoguePanel;       // same panel Gordon used
    public TextMeshProUGUI dialogueText;   // same text Gordon used

    [Header("Item References (optional visuals)")]
    public GameObject tutorialPlateObject;
    public GameObject tutorialBunObject;
    public GameObject tutorialPattyObject;
    public GameObject tutorialBurgerObject;

    private bool tutorialActive = false;
    private bool tutorialComplete = false;

    private TutorialStep currentStep = TutorialStep.None;

    void Awake()
    {
        // Don’t run until Gordon finishes
        enabled = false;
    }

    public void BeginTutorial()
    {
        tutorialActive = true;
        tutorialComplete = false;
        enabled = true;

        SetStep(TutorialStep.GetPlate);
    }

    private void SetStep(TutorialStep step)
    {
        currentStep = step;

        if (dialoguePanel != null && !dialoguePanel.activeSelf)
            dialoguePanel.SetActive(true);

        switch (step)
        {
            case TutorialStep.GetPlate:
                dialogueText.text = "Alright chef, first grab a plate.";
                break;

            case TutorialStep.GetBun:
                dialogueText.text = "Good. Now grab a bun from the station.";
                break;

            case TutorialStep.PlaceFirstBun:
                dialogueText.text = "Now place the bun on the plate on the assembly tray.";
                break;

            case TutorialStep.GetPatty:
                dialogueText.text = "Next, pick up a raw patty.";
                break;

            case TutorialStep.CookPatty:
                dialogueText.text = "Take that patty to the grill and cook it.";
                break;

            case TutorialStep.AssembleBurger:
                dialogueText.text = "Great. Now place the cooked patty on the bun.";
                break;

            case TutorialStep.AddLettuce:
                dialogueText.text = "Now add some lettuce to the burger.";
                break;

            case TutorialStep.AddTopBun:
                dialogueText.text = "Finally, add the top bun to finish the burger.";
                break;

            case TutorialStep.DeliverBurger:
                dialogueText.text = "Perfect. Deliver that burger to the counter.";
                break;

            case TutorialStep.Complete:
                dialogueText.text = "Nice job! You know how to make a proper burger.";
                tutorialActive = false;
                tutorialComplete = true;
                break;

            case TutorialStep.PlacePlate:
                dialogueText.text = "Now place the plate on the assembly tray.";
                break;

        }
    }

    // ----------------- Hooks called from interactables -----------------

    public void OnPlatePickedUp()
    {
        if (!tutorialActive || tutorialComplete) return;
        if (currentStep != TutorialStep.GetPlate) return;

        SetStep(TutorialStep.PlacePlate);
    }

    public void OnPlatePlacedOnTray()
    {
        if (!tutorialActive || tutorialComplete) return;
        if (currentStep != TutorialStep.PlacePlate) return;

        SetStep(TutorialStep.GetBun);
    }

    public void OnBunPickedUp()
    {
        if (!tutorialActive || tutorialComplete) return;
        if (currentStep != TutorialStep.GetBun) return;

        if (tutorialBunObject != null)
            tutorialBunObject.SetActive(false);

        // OLD: SetStep(TutorialStep.GetPatty);
        // NEW:
        SetStep(TutorialStep.PlaceFirstBun);
    }

    public void OnFirstBunPlaced()
    {
        if (!tutorialActive || tutorialComplete) return;
        if (currentStep != TutorialStep.PlaceFirstBun) return;

        SetStep(TutorialStep.GetPatty);
    }




    public void OnPattyPickedUp()
    {
        if (!tutorialActive || tutorialComplete) return;
        if (currentStep != TutorialStep.GetPatty) return;

        if (tutorialPattyObject != null)
            tutorialPattyObject.SetActive(false);

        SetStep(TutorialStep.CookPatty);
    }

    public void OnPattyCooked()
    {
        if (!tutorialActive || tutorialComplete) return;
        if (currentStep != TutorialStep.CookPatty) return;

        SetStep(TutorialStep.AssembleBurger);
    }

    public void OnBurgerAssembled()
    {
        if (!tutorialActive || tutorialComplete) return;
        if (currentStep != TutorialStep.AssembleBurger) return;

        if (tutorialBurgerObject != null)
            tutorialBurgerObject.SetActive(true);

        SetStep(TutorialStep.AddLettuce);
    }

    public void OnLettucePlaced()
    {
        if (!tutorialActive || tutorialComplete) return;
        if (currentStep != TutorialStep.AddLettuce) return;

        SetStep(TutorialStep.AddTopBun);
    }

    public void OnTopBunPlaced()
    {
        if (!tutorialActive || tutorialComplete) return;
        if (currentStep != TutorialStep.AddTopBun) return;

        SetStep(TutorialStep.DeliverBurger);
    }

    public void OnBurgerDelivered()
    {
        if (!tutorialActive || tutorialComplete) return;
        if (currentStep != TutorialStep.DeliverBurger) return;

        SetStep(TutorialStep.Complete);
    }
}
