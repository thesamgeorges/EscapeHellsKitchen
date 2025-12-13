using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCoolerDoor : MonoBehaviour
{
    public GameObject manager;
    void OnTriggerEnter(Collider coll)
    {

        GameObject collidedWith = coll.gameObject;


        if (collidedWith.CompareTag("Player")&& manager.GetComponent<handsScript>().hasCoolerKey == true)
        {
            SceneManager.LoadSceneAsync("CoolerScene");
        }
         
    }
}
