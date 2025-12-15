using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStorageDoorKitchen : MonoBehaviour
{
    private handsScript manager;
    void Start()
    {
        manager = FindObjectOfType<handsScript>();
    }
    void OnTriggerEnter(Collider coll)
    {

        GameObject collidedWith = coll.gameObject;

        if (collidedWith.CompareTag("Player")&& manager.GetComponent<handsScript>().hasStorageKey == true)
        {
            SceneLoader.Instance.LoadStorageScene();
            SceneLoader.Instance.UnloadScene("KitchenScene");
        }
         
    }
}
