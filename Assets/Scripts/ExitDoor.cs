using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider coll)
    {
        //collision gameObject
        GameObject collidedWith = coll.gameObject;


        //if the player collides with the door
        if (collidedWith.CompareTag("Player"))
        {
            //load the cage scene
            SceneManager.LoadSceneAsync("CageScene");

        }
         
    }
}
