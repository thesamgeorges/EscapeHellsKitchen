using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToKitchenDoor : MonoBehaviour
{
    public GameObject manager;
    void OnTriggerEnter(Collider coll)
    {

        GameObject collidedWith = coll.gameObject;


        if (collidedWith.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync("Kitchen Scene");
        }
         
    }
}
