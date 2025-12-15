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
        };  
        
    }
    public void LoadStorageScene()
    {
        var op = SceneManager.LoadSceneAsync("StorageScene", LoadSceneMode.Additive);
        op.completed += _ =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("StorageScene"));
            teleport(new Vector3(-0.821461f, -1.07f, 3.15f));
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
