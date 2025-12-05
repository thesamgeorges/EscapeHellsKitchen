using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public GameObject[] orderPanels; // Assign in Inspector
    private GameObject currentPanel;

    void Start()
    {
        StartNewOrder();
    }

    public void StartNewOrder()
    {
        // Hide all order panels
        foreach (GameObject panel in orderPanels)
            panel.SetActive(false);

        // Pick one order
        currentPanel = orderPanels[Random.Range(0, orderPanels.Length)];
        currentPanel.SetActive(true);
    }

    public void CompleteOrder()
    {
        Debug.Log("Order completed!");
        StartNewOrder();
    }
}
