using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndOfDayDialogue : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;          // whole panel for Gordon's dialogue

    [Header("Dialogue Lines")]
    [TextArea(2, 4)]
    public string[] lines;

    [Header("Cage Scene")]
    public EndOfDayDialogue cutScene;            // reference to your tutorial script
    public MonoBehaviour playerController;    // your movement script
    public SleepFader sleepFader; //for fading in and out of the cage scene

    private int currentIndex = 0;
    private bool dialogueActive = true;

    void Start()
    {

        if (lines.Length > 0)
        {
            currentIndex = 0;
            dialogueText.text = lines[currentIndex];
        }

        if (dialoguePanel != null)
            dialoguePanel.SetActive(true);

        // Player should not be able to move
        if (playerController != null)
            playerController.enabled = false;
    }

    void Update()
    {
        if (!dialogueActive)
            return;

        // Press Enter to continue
        if (Input.GetKeyDown(KeyCode.Return))
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

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        // instead of loading immediately:
        if (sleepFader != null)
        {
            sleepFader.StartSleepFade("CageCutScene");
        }
        else
        {
            SceneLoader.Instance.loadCageCutScene(); // fallback
            SceneLoader.Instance.unloadAll("CageCutScene");
        }
    }
}