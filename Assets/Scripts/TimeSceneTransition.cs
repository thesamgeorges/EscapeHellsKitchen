using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedSceneTransition : MonoBehaviour
{
    [Tooltip("How long this scene should stay on screen (in seconds).")]
    public float delay = 3f;

    [Tooltip("Name of the scene to load after the delay.")]
    public string nextSceneName;

    [Header("Player Movement")]
    private PlayerMovement playerController;   
    private handsScript manager;


    void Start()
    {
        manager = FindAnyObjectByType<handsScript>();
        manager.isGame = false;
        playerController = FindAnyObjectByType<PlayerMovement>();
        {
            if (playerController != null)
                playerController.enabled = false;

            StartCoroutine(LoadAfterDelay());
        }
    }

    private System.Collections.IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSecondsRealtime(delay);
        playerController.enabled = true;
        manager.isGame = true;
        SceneLoader.Instance.LoadKitchenScene();
        SceneLoader.Instance.UnloadScene("CageCutScene");
        
    }
}
