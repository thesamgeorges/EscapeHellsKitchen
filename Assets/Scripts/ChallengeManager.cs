using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChallengeManager : MonoBehaviour
{
    public int requiredHits = 30;
    public float challengeDuration = 5f;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI hitText;
    public TextMeshProUGUI resultText;

    public GameObject enemy;
    public GameObject keyPrefab;     // purely visual now
    public Transform keySpawnPoint;  // optional — otherwise uses enemy position

    private int currentHits = 0;
    private float timeLeft;
    private bool challengeActive = false;

    void Start()
    {
        timeLeft = challengeDuration;
        resultText.text = "";
        hitText.text = "Hits: 0";
        timerText.text = "Time: " + timeLeft.ToString("0.00");
        challengeActive = true;
    }

    void Update()
    {
        if (!challengeActive) return;

        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + timeLeft.ToString("0.00");

        if (timeLeft <= 0)
        {
            EndChallenge(false);
        }
    }

    public void RegisterHit()
    {
        if (!challengeActive) return;

        currentHits++;
        hitText.text = "Hits: " + currentHits;

        if (currentHits >= requiredHits)
        {
            EndChallenge(true);
        }
    }

    void EndChallenge(bool success)
    {
        challengeActive = false;

        if (success)
        {
            resultText.text = "YOU ESCAPED!";

            // Spawn the key visual (optional)
            if (keyPrefab != null)
            {
                Vector3 spawnPos = enemy != null ? enemy.transform.position : transform.position;
                if (keySpawnPoint != null)
                    spawnPos = keySpawnPoint.position;

                // Instantiate(keyPrefab, spawnPos, Quaternion.identity);
                Instantiate(keyPrefab, spawnPos, keyPrefab.transform.rotation);

            }

            // Remove the enemy
            if (enemy != null)
                Destroy(enemy);

            // Return to menu after 2 seconds
            StartCoroutine(ReturnToMenu());
        }
        else
        {
            resultText.text = "YOU LOSE!";
            StartCoroutine(ReturnToMenu());
        }
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }

    public bool IsActive()
    {
        return challengeActive;
    }
}
