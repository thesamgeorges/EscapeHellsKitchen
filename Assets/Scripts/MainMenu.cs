using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    [SerializeField] private string gameSceneName = "Kitchen Scene";

    public void PlayGame()
    {
        // Load the game scene
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenOptions()
    {
        // just log, or later open an options panel
        Debug.Log("Options menu not implemented yet.");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

