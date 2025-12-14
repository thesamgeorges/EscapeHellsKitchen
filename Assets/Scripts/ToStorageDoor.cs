using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStorageDoor : MonoBehaviour
{
    public GameObject manager;
    void OnTriggerEnter(Collider coll)
    {

        GameObject collidedWith = coll.gameObject;


        if (collidedWith.CompareTag("Player")&& manager.GetComponent<handsScript>().hasStorageKey == true)
        {
            SceneManager.LoadSceneAsync("StorageScene");
        }
         
    }
}
