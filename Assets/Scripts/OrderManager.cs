using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;
public class OrderManager : MonoBehaviour
{
    public GameObject[] orderPanels; // Assign in Inspector
    public GameObject PlayerUI; //currentOrder popup inside Player's UI 
    public GameObject OrderTimer; // timermanager(order) inside Player's UI
    public AudioSource source;
    public AudioClip orderHereSound;
    public string currentOrder;
    public bool hasOrder;
    private handsScript manager;
    private IntroTutorial tut;

    void Start()
    {
        manager = FindAnyObjectByType<handsScript>();
        if (manager.inTutorial == true)
        {
            tut = FindAnyObjectByType<IntroTutorial>();
        }
        ;
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
        int choice;
        if (manager.inTutorial == false)
        {
            PlayerUI.SetActive(true); // makes the player's You have an order! UI popup appear
            OrderTimer.GetComponent<timerManagerOrder>().ResetTime(); // resets the timer for popup
            source.PlayOneShot(orderHereSound);

            System.Random random = new System.Random();
            choice = random.Next(2);

        }
        else
        {
            choice = 0;
        }

        hasOrder = true;

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
        hasOrder = false;
        PlayerUI.SetActive(false);
        foreach (GameObject panel in orderPanels)
        {
            panel.SetActive(false); // have the panel gone by defaul
        }
        Debug.Log("Order completed!");
        if(manager.inTutorial==false){
            StartCoroutine(SetTimer());
        }
        else
        {
            tut.OnBurgerDelivered();
        }
    }
}
