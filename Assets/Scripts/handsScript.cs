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
    void Start()
    {
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
                SceneManager.LoadSceneAsync("CageScene");
                player.localPosition = new Vector3(-2.04976f, 1.48f, -3.3407f);
                player.localRotation = Quaternion.Euler(0f, -2.125f, 0f);
                break;
            default:
                break;
        }

    }

    public void openNote(GameObject notes)
    {
        note = notes;
        note.SetActive(true);
        isNoteOpen = true;
    }

    void Update()
    {
        if (isNoteOpen && Input.GetKeyDown(KeyCode.E))
        {
            note.SetActive(false);
            isNoteOpen = false;
            note = null;
        }
    }
    public void Set(string item)
    {
        obj = item;
        textMesh.text = "Currently holding: " + obj;
    }
}
