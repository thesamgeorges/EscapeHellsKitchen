using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shotgun : MonoBehaviour, IInteractable
{
    public string sceneToLoad = "BossFight";   

    public void Interact()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
