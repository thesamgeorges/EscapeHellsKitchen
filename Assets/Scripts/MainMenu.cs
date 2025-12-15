using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        // Load the game scene
        SceneLoader.Instance.LoadTutorial();
        SceneLoader.Instance.UnloadScene("MainMenu");
    }

    public void SkipTutorial()
    {
       SceneLoader.Instance.LoadKitchenScene();
       SceneLoader.Instance.UnloadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        SceneLoader.Instance.UnloadScene("MainMenu");
   
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

