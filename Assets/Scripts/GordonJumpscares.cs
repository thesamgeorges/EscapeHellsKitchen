using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GordonJumpscares : MonoBehaviour
{
    public Transform gordon;
    public GameObject Gordon;
    public GameObject cam;
    public AudioSource source;
    public AudioClip ScareClip;
    public GameObject overlay;
    public MonoBehaviour scriptToDisable;

    void Start()
    {
      Gordon.SetActive(false);  
      overlay.SetActive(false);
    }
    IEnumerator SetTimer()
    {
        yield return new WaitForSeconds(3f);
        Gordon.SetActive(false);
        overlay.SetActive(false);
        scriptToDisable.enabled = true;
    }
    public void scare()
    {
        source.PlayOneShot(ScareClip);
        scriptToDisable.enabled = false;
        overlay.SetActive(true);
        Gordon.SetActive(true);
        Transform camT = cam.transform;
        gordon.SetParent(camT);
        gordon.localPosition = new Vector3(2.2f, -4.75f, .8f);
        gordon.localRotation = Quaternion.Euler(0f, 180f, -25f);
        gordon.localScale = new Vector3(2f, 2f, 2f);

        StartCoroutine(SetTimer());

    }   
}
