using UnityEngine;
using System;
using System.Collections;
public class OrderManager : MonoBehaviour
{
    public GameObject[] orderPanels; // Assign in Inspector
    public GameObject PlayerUI; //currentOrder popup inside Player's UI 
    public GameObject OrderTimer; // timermanager(order) inside Player's UI
    public AudioSource source;
    public AudioClip orderHereSound;
    public string currentOrder;

    void Start()
    {
        StartNewOrder();
    }

    public string Get()
    {
        return currentOrder;
    }

    IEnumerator SetTimer()
    {
        System.Random random = new System.Random();
        float cooldown = random.Next(120);
        yield return new WaitForSeconds(cooldown);
        StartNewOrder();
    }

    public void StartNewOrder()
    {
        PlayerUI.SetActive(true); // makes the player's You have an order! UI popup appear
        OrderTimer.GetComponent<timerManagerOrder>().ResetTime(); // resets the timer for popup
        source.PlayOneShot(orderHereSound);
        
        System.Random random = new System.Random();
        int choice = random.Next(2);

        if (choice == 0)
        {
            currentOrder = "burger";
            Console.WriteLine($"Current order is: {currentOrder}");
        }
        else
        {
            currentOrder = "cheeseburger";
            Console.WriteLine($"Current order is: {currentOrder}");
        }

        foreach (GameObject panel in orderPanels)
        {
            panel.SetActive(false); // have the panel gone by defaul
        }

        if (currentOrder == "burger")
        {
            orderPanels[0].SetActive(true);            
        }
        else if (currentOrder == "cheeseburger")
        {
            orderPanels[1].SetActive(true);            
        }
    }

    public void CompleteOrder()
    {
        PlayerUI.SetActive(false);
        foreach (GameObject panel in orderPanels)
        {
            panel.SetActive(false); // have the panel gone by defaul
        }
        Debug.Log("Order completed!");
        StartCoroutine(SetTimer());
    }
}
