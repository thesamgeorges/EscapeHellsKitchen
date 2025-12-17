using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepFader : MonoBehaviour
{
    [Header("Fade Target")]
    public CanvasGroup fadeGroup;       // assign your FadeOverlay CanvasGroup here

    [Header("Timing")]
    public float fadeDuration = 2f;     // how long to fade
    public float holdBlackTime = 1f;    // how long to stay fully black

    void Start()
    {
        // Optional: start fully black and fade in at scene start
        if (fadeGroup != null)
        {
            fadeGroup.alpha = 1f;
            StartCoroutine(FadeInFromBlack());
        }
    }

    public void StartSleepFade(string nextSceneName)
    {
        // Call this when player "goes to sleep"
        if (fadeGroup != null)
            StartCoroutine(FadeOutToBlackThenLoad(nextSceneName));
    }

    public void StartSleepFadeNoScene(System.Action onComplete = null)
    {
        // If you just want a fade and then callback, use this version
        if (fadeGroup != null)
            StartCoroutine(FadeOutToBlackThenCallback(onComplete));
    }

    private IEnumerator FadeInFromBlack()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalized = t / fadeDuration;
            fadeGroup.alpha = 1f - normalized;
            yield return null;
        }
        fadeGroup.alpha = 0f;
    }

    private IEnumerator FadeOutToBlackThenLoad(string sceneName)
    {
        // fade out
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalized = t / fadeDuration;
            fadeGroup.alpha = normalized;
            yield return null;
        }
        fadeGroup.alpha = 1f;

        // hold on black
        yield return new WaitForSeconds(holdBlackTime);

        // load next scene
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private IEnumerator FadeOutToBlackThenCallback(System.Action onComplete)
    {
        // fade out
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalized = t / fadeDuration;
            fadeGroup.alpha = normalized;
            yield return null;
        }
        fadeGroup.alpha = 1f;

        // hold on black
        yield return new WaitForSeconds(holdBlackTime);

        onComplete?.Invoke();
    }
}

