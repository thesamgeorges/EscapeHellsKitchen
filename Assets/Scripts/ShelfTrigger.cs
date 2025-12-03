using UnityEngine;

public class ShelfTriggerZone : MonoBehaviour
{
    public IntroTutorial tutorial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            tutorial.OnPlayerEnteredShelfArea();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            tutorial.OnPlayerLeftShelfArea();
    }
}


