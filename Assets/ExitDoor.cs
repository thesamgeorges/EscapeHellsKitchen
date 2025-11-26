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

        GameObject collidedWith = coll.gameObject;


        if (collidedWith.CompareTag("Player"))
        {

            SceneManager.LoadSceneAsync("CageScene");

        }
         
    }
}
