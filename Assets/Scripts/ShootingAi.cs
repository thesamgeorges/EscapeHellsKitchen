using UnityEngine;

public class ShootingAi : MonoBehaviour
{
    public int health = 999999; // stays alive for whole challenge
    public ChallengeManager challenge;

public void TakeDamage(int damage)
{
    Debug.Log("Enemy was shot! Took " + damage + " damage.");

    health -= damage;

    if (health <= 0)
    {
        Debug.Log("Enemy died!");
        // Keep or remove depending on your challenge
        // Destroy(gameObject);
    }
}
}
