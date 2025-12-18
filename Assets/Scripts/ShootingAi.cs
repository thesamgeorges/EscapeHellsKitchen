using UnityEngine;

public class ShootingAi : MonoBehaviour
{
    public int health = 999999; // stays alive during challenge
    public ChallengeManager challenge;

    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy was shot! Took " + damage + " damage.");

        health -= damage;

        // Register hit with the challenge
        if (challenge != null)
        {
            challenge.RegisterHit();
        }
        else
        {
            Debug.LogWarning("No ChallengeManager assigned to ShootingAi!");
        }

        if (health <= 0)
        {
            Debug.Log("Enemy died! (Optional)");
        }
    }
}
