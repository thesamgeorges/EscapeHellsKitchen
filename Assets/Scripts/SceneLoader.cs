using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Transform player;
    public static SceneLoader Instance;
    CharacterController cc;
    void Start()
    {
        LoadKitchenScene();
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
    public void LoadCageScene()
    {
        SceneManager.LoadSceneAsync("CageScene", LoadSceneMode.Additive);
    }
    public void LoadKitchenScene()
    {
        var op = SceneManager.LoadSceneAsync("KitchenScene", LoadSceneMode.Additive);
        op.completed += _ =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("KitchenScene"));
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
