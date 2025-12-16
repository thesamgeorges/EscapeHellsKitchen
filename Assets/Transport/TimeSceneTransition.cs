using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedSceneTransition : MonoBehaviour
{
    [Tooltip("How long this scene should stay on screen (in seconds).")]
    public float delay = 5f;

    [Tooltip("Name of the scene to load after the delay.")]
    public string nextSceneName;

    [Header("Player Movement")]
    public MonoBehaviour playerController;   


    void Start()
    {
        {
            if (playerController != null)
                playerController.enabled = false;

            StartCoroutine(LoadAfterDelay());
        }
    }

    private System.Collections.IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("TimedSceneTransition: nextSceneName is empty.");
        }
    }
}
