using System;
using UnityEngine;

public class DriveThroughWindow : MonoBehaviour, IInteractable
{
    public OrderManager orderManager;
    public GameObject manager;
    public AudioSource AudioSource;
    public AudioClip soundEffect;

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
            Console.WriteLine("ur not holding a burger");
        }
    }
}
