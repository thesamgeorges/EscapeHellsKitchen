using UnityEngine;

public class EnemyTeleporter : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float teleportInterval = 0.5f;
    public ChallengeManager challenge;

    private float timer = 0f;
    private bool goingRight = true;

    void Update()
    {
        // Stop moving once challenge is done
        if (challenge != null && !challenge.IsActive())
            return;

        timer += Time.deltaTime;

        if (timer >= teleportInterval)
        {
            Teleport();
            timer = 0f;
        }
    }

    void Teleport()
    {
        if (goingRight)
            transform.position = rightPoint.position;
        else
            transform.position = leftPoint.position;

        goingRight = !goingRight;
    }
}
