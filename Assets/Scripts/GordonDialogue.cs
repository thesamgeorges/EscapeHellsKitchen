using UnityEngine;
using TMPro;

public class GordonDialogue : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;          // optional (for "Gordon")
    public GameObject dialoguePanel;          // whole panel for Gordon's dialogue

    [Header("Dialogue Lines")]
    [TextArea(2, 4)]
    public string[] lines;

    [Header("Tutorial")]
    public IntroTutorial tutorial;            // reference to your tutorial script
    public MonoBehaviour playerController;    // your movement script

    private int currentIndex = 0;
    private bool dialogueActive = true;

    void Start()
    {
        if (nameText != null)
            nameText.text = "Gordon";

        if (lines.Length > 0)
        {
            currentIndex = 0;
            dialogueText.text = lines[currentIndex];
        }

        if (dialoguePanel != null)
            dialoguePanel.SetActive(true);

        // ❌ Player should NOT move while Gordon talks
        if (playerController != null)
            playerController.enabled = false;
    }

    void Update()
    {
        if (!dialogueActive)
            return;

        // Press Enter or Space to continue
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceDialogue();
        }
    }

    public void AdvanceDialogue()
    {
        currentIndex++;

        if (currentIndex >= lines.Length)
        {
            EndDialogue();
        }
        else
        {
            dialogueText.text = lines[currentIndex];
        }
    }

    private void EndDialogue()
    {
        dialogueActive = false;

        // Hide Gordon's dialogue UI
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        // ✅ Re-enable player movement now that he's done talking
        if (playerController != null)
            playerController.enabled = true;

        // Start the tutorial
        if (tutorial != null)
        {
            tutorial.BeginTutorial();
        }
        else
        {
            Debug.LogWarning("GordonDialogue: No IntroTutorial assigned, cannot start tutorial.");
        }
    }
}
