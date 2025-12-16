using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class handsScript : MonoBehaviour
{
    public TMP_Text textMesh;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject order;
    private string obj;
    private GameObject note;
    private bool isNoteOpen;
    private int lives;
    public bool hasCoolerKey;
    public bool hasDungeonKey;
    public bool hasStorageKey;
    public Transform player;
    public bool inTutorial;
    public int day;
    public TextMeshProUGUI daytxt;
    private EndOfDayDialogue end;
    private TimedSceneTransition end2;
    public GameObject UI;
    public GameObject timerManager;
    public bool isGame;

    void Start()
    {
        day = 1;
        hasCoolerKey = false;
        hasDungeonKey = false;
        hasStorageKey = false; 
        order.SetActive(false);
        life3.SetActive(true);
        life2.SetActive(true);
        life1.SetActive(true);
        lives = 3;
        obj = "nothing";
        isNoteOpen = false;
        note = null;
        textMesh.text = "Currently holding: nothing";

    }
    public string Get()
    {
        return obj;
    }

    public void removeLife()
    {
        lives=lives-1;

        switch (lives)
        {
            case 2:
                life3.SetActive(false);
                break;
            case 1:
                life2.SetActive(false);
                break;
            case 0:
                life1.SetActive(false);
                SceneLoader.Instance.LoadCageScene(true);
                player.localPosition = new Vector3(-2.04976f, 1.48f, -3.3407f);
                player.localRotation = Quaternion.Euler(0f, -2.125f, 0f);
                break;
            default:
                break;
        }

    }

    public void IncrementDay()
    {
        day+=1;
        timerManager.GetComponent<TimerManager>().resetTime();
    }

    public void openNote(GameObject notes)
    {
        note = notes;
        note.SetActive(true);
        isNoteOpen = true;
    }

    void Update()
    {
        end = FindAnyObjectByType<EndOfDayDialogue>();
        end2 = FindAnyObjectByType<TimedSceneTransition>();
        if (end != null||end2 != null)
        {
            UI.SetActive(false);
            isGame = false;
        }
        else
        {
            UI.SetActive(true);
            isGame = true;
        }

        if (isNoteOpen && Input.GetKeyDown(KeyCode.E))
        {
            note.SetActive(false);
            isNoteOpen = false;
            note = null;
        }
        daytxt.text = "Day "+ day.ToString();
    }
    public void Set(string item)
    {
        obj = item;
        textMesh.text = "Currently holding: " + obj;
    }
}
