using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroTutorial : MonoBehaviour
{
    [Header("Player & Item")]
    public GameObject tutorialItem;                 // the item sitting on the shelf
    public Transform player;                        // your player object (optional, for reference)

    [Header("UI")]
    public TextMeshProUGUI objectiveText;           // top text: "Go to the shelf..."
    public TextMeshProUGUI interactPromptText;      // bottom text: "Press E to pick up"

    [Header("Next Scene (optional)")]
    public string nextSceneName = "Kitchen Scene";  // your real gameplay scene

    private bool tutorialActive = false;
    private bool playerAtShelf = false;
    private bool tutorialComplete = false;

    void Awake()
    {
        // Tutorial should NOT run immediately — Gordon triggers it later
        enabled = false;

        if (objectiveText != null)
            objectiveText.text = "";

        if (interactPromptText != null)
            interactPromptText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Called by GordonDialogue when Gordon finishes talking.
    /// </summary>
    public void BeginTutorial()
    {
        tutorialActive = true;
        enabled = true;

        if (objectiveText != null)
            objectiveText.text = "Go to the fridge and press E to grab a steak.";

        if (interactPromptText != null)
            interactPromptText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!tutorialActive || tutorialComplete)
            return;

        // Player presses E while near the shelf
        if (playerAtShelf && Input.GetKeyDown(KeyCode.E))
        {
            HandlePickup();
        }
    }

    /// <summary>
    /// Called by ShelfTriggerZone when player enters trigger.
    /// </summary>
    public void OnPlayerEnteredShelfArea()
    {
        if (!tutorialActive || tutorialComplete)
            return;

        playerAtShelf = true;

        if (interactPromptText != null)
            interactPromptText.gameObject.SetActive(true);
    }

    /// <summary>
    /// Called by ShelfTriggerZone when player exits trigger.
    /// </summary>
    public void OnPlayerLeftShelfArea()
    {
        if (!tutorialActive || tutorialComplete)
            return;

        playerAtShelf = false;

        if (interactPromptText != null)
            interactPromptText.gameObject.SetActive(false);
    }

    private void HandlePickup()
    {
        tutorialComplete = true;

        if (tutorialItem != null)
            tutorialItem.SetActive(false); // simple pickup behavior

        if (objectiveText != null)
            objectiveText.text = " You picked up a steak.";

        if (interactPromptText != null)
            interactPromptText.gameObject.SetActive(false);

        // OPTIONAL: Load next scene automatically
        // SceneManager.LoadScene(nextSceneName);
    }
}
