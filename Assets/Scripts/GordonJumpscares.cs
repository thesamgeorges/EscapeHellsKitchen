using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GordonJumpscares : MonoBehaviour
{
    public Transform gordon;
    public GameObject body;
    public GameObject cam;
    public AudioSource source;
    public AudioClip ScareClip;
    public GameObject overlay;
    public MonoBehaviour scriptToDisable;
    public handsScript manager;

    void Start()
    {
      body.SetActive(false);  
      overlay.SetActive(false);
      
    }
    IEnumerator SetTimer()
    {
        yield return new WaitForSeconds(3f);
        body.SetActive(false);
        overlay.SetActive(false);
        scriptToDisable.enabled = true;
    }

    void Update()
    {
        
    }
    IEnumerator RandTimer()
    {
        System.Random random = new System.Random();
        float cooldown = random.Next(60,180);
        yield return new WaitForSeconds(cooldown);
        yield return new WaitForSeconds(3);
        scare();
        RandTimer();
    }
    public void scare()
    {
        source.PlayOneShot(ScareClip);
        scriptToDisable.enabled = false;
        overlay.SetActive(true);
        body.SetActive(true);
        Transform camT = cam.transform;
        gordon.SetParent(camT);
        gordon.localPosition = new Vector3(2.2f, -4.75f, .8f);
        gordon.localRotation = Quaternion.Euler(0f, 180f, -25f);
        gordon.localScale = new Vector3(2f, 2f, 2f);

        StartCoroutine(SetTimer());

    }   
}
