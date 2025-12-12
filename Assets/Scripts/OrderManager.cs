using UnityEngine;
using System;
public class OrderManager : MonoBehaviour
{
    public GameObject[] orderPanels; // Assign in Inspector
    public GameObject PlayerUI; //currentOrder popup inside Player's UI 
    public GameObject OrderTimer; // timermanager(order) inside Player's UI

    public string currentOrder;

    void Start()
    {
        StartNewOrder();
    }

    public string Get()
    {
        return currentOrder;
    }
    
    public void StartNewOrder()
    {
        PlayerUI.SetActive(true); // makes the player's You have an order! UI popup appear
        OrderTimer.GetComponent<timerManagerOrder>().ResetTime(); // resets the timer for popup

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
        Debug.Log("Order completed!");
        StartNewOrder();
    }
}
