using UnityEngine;
using TMPro;

public class ChallengeManager : MonoBehaviour
{
    public int requiredHits = 30;
    public float challengeDuration = 5f;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI hitText;
    public TextMeshProUGUI resultText;

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
            resultText.text = "YOU WIN!";
        else
            resultText.text = "YOU LOSE!";
    }
}
