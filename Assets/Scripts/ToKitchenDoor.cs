using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToKitchenDoor : MonoBehaviour
{
    private handsScript manager;
    void Start()
    {
        manager = FindObjectOfType<handsScript>();
    }
    void OnTriggerEnter(Collider coll)
    {

        GameObject collidedWith = coll.gameObject;

        if (collidedWith.CompareTag("Player"))
        {
            SceneLoader.Instance.LoadKitchenScene();
            SceneLoader.Instance.UnloadScene("StorageScene");
        }
         
    }
}
