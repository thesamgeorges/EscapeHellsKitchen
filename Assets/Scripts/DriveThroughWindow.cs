using UnityEngine;

public class DriveThroughWindow : MonoBehaviour
{
    public OrderManager orderManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinalProduct"))
        {
            orderManager.CompleteOrder();
            Destroy(other.gameObject); // Remove delivered item
        }
    }
}
