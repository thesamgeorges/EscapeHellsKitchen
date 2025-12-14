using System;
using UnityEngine;

public class DriveThroughWindow : MonoBehaviour, IInteractable
{
    public AudioSource AudioSource;
    public AudioClip soundEffect;
    private GordonJumpscares gordon;
    private handsScript manager;
    private OrderManager orderManager;
    void Start()
    {
        manager = FindObjectOfType<handsScript>();
        orderManager = FindObjectOfType<OrderManager>();
        gordon = FindObjectOfType<GordonJumpscares>();
    }
    public void Interact()
    {

        if (manager.GetComponent<handsScript>().Get() == orderManager.GetComponent<OrderManager>().Get())
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
}
