using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Transform player;
    public static SceneLoader Instance;
    CharacterController cc;
    public GameObject Player;
    public GameObject canvas;
    public GameObject manager;
    public GameObject orderManager;
   
   public void unloadAll()
    {
        StartCoroutine(kill());
    }
   
    private IEnumerator kill()
    {
        yield return SceneManager.UnloadSceneAsync("KitchenScene");
        yield return SceneManager.UnloadSceneAsync("CageScene");
        yield return SceneManager.UnloadSceneAsync("CageCutScene");
        yield return SceneManager.UnloadSceneAsync("StorageScene");
        yield return SceneManager.UnloadSceneAsync("CoolerScene");
        yield return SceneManager.UnloadSceneAsync("TutorialScene");
        yield return SceneManager.UnloadSceneAsync("MainMenu");
        yield return SceneManager.UnloadSceneAsync("EndOfDayCutScene");
    }
   
    void Start()
    {
        LoadMenu();
        Player.SetActive(false);
        canvas.SetActive(false);
        orderManager.SetActive(false);
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        cc = player.GetComponent<CharacterController>();

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadTutorial()
    {
        var op = SceneManager.LoadSceneAsync("TutorialScene", LoadSceneMode.Additive);
        op.completed += _ =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("TutorialScene"));
            Player.SetActive(true);
            canvas.SetActive(true);
            orderManager.SetActive(true);
            manager.GetComponent<handsScript>().inTutorial = true;
            teleport(new Vector3(3.24f, 0.84f, 16.85f));
            player.rotation=Quaternion.Euler(0f, 206.105f, 0f);
        };  
    }
    public void LoadMenu()
    {
        var op = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        op.completed += _ =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));
            canvas.SetActive(false);
            Player.SetActive(false);
            orderManager.SetActive(false);
        };  
    }
    public void LoadCageScene(bool inCage)
    {
        var op = SceneManager.LoadSceneAsync("CageScene", LoadSceneMode.Additive);
        op.completed += _ =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("CageScene"));
        };
        if (inCage)
        {
           // teleport(new Vector3()); 
        }
        else
        {
           // teleport(new Vector3()); 
        }
    }
    public void LoadKitchenScene()
    {
        var op = SceneManager.LoadSceneAsync("KitchenScene", LoadSceneMode.Additive);
        op.completed += _ =>
        {
            manager.GetComponent<handsScript>().inTutorial = false;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("KitchenScene"));
            Player.SetActive(true);
            canvas.SetActive(true);
            orderManager.SetActive(true);
            teleport(new Vector3(3.24f, 0.84f, 16.85f));
            player.localScale = new Vector3(1f,1.5f,1f);
        };  
        
    }
    public void loadEndofDayOne()
    {
        var op = SceneManager.LoadSceneAsync("EndOfDayCutScene", LoadSceneMode.Additive);
        op.completed += _ =>
        {
            player.rotation=Quaternion.Euler(0f, 0f, 0f);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("EndOfDayCutScene"));
            teleport(new Vector3(1.35f, 0.84f, 13.23f));
            player.rotation=Quaternion.Euler(-25f, 180f, 0f);
        };  
    }
    public void loadCageCutScene()
    {
        var op = SceneManager.LoadSceneAsync("CageCutScene", LoadSceneMode.Additive);
        op.completed += _ =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("CageCutScene"));
            teleport(new Vector3(-2.03f, 1.29f, -3.381f));
            player.rotation=Quaternion.Euler(0f, 0f, 0f);
        };  
    }

    public void LoadStorageScene()
    {
        var op = SceneManager.LoadSceneAsync("StorageScene", LoadSceneMode.Additive);
        op.completed += _ =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("StorageScene"));
            teleport(new Vector3(-0.821461f, -1.07f, 3.15f));
            player.localScale = new Vector3(1f,1f,1f);
        };  
    }
    public void LoadCoolerScene()
    {
        var op = SceneManager.LoadSceneAsync("CoolerScene", LoadSceneMode.Additive);
        op.completed += _ =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("CoolerScene"));
            teleport(new Vector3 (3.693087f, -0.1f, 1.732821f));
        };  
    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void teleport(Vector3 pos)
    {
        cc.enabled = false;
        player.position = pos;
        cc.enabled = true;
    }
}
