using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCoolerDoor : MonoBehaviour
{
    private handsScript manager;
    void Start()
    {
        manager = FindObjectOfType<handsScript>();
        
    }
    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.CompareTag("Player")&& manager.GetComponent<handsScript>().hasCoolerKey == true)
        {
            SceneLoader.Instance.LoadCoolerScene();
            SceneLoader.Instance.UnloadScene("StorageScene");
        }
         
    }
}
