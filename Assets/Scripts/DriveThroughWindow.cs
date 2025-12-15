using System;
using UnityEngine;

public class DriveThroughWindow : MonoBehaviour, IInteractable
{
    private AudioSource AudioSource;
    public AudioClip soundEffect;
    private GordonJumpscares gordon;
    private handsScript manager;
    private OrderManager orderManager;
    public GameObject car;
    void Start()
    {
        manager = FindObjectOfType<handsScript>();
        orderManager = FindObjectOfType<OrderManager>();
        gordon = FindObjectOfType<GordonJumpscares>();
        AudioSource = FindObjectOfType<AudioSource>();
    }
    public void Interact()
    {

        if (manager.Get() == orderManager.Get())
        {
            AudioSource.PlayOneShot(soundEffect);
            orderManager.CompleteOrder();
            manager.GetComponent<handsScript>().Set("nothing");
        }
        else
        {
            gordon.GetComponent<GordonJumpscares>().scare();
            manager.GetComponent<handsScript>().removeLife();
            Console.WriteLine("ur not holding a burger");
        }
    }

    void Update()
    {
        if(orderManager.hasOrder == true)
        {
            car.SetActive(true);
        }
        else
        {
            car.SetActive(false);
        }
    }
}
