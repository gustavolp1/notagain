using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f;
    public Collider doorTriggerCollider;

    public void FadeAndLoadNextLevel()
    {
        StartCoroutine(FadeAndSwitchLevel());
    }

    private IEnumerator FadeAndSwitchLevel()
    {
        if (doorTriggerCollider != null)
            doorTriggerCollider.enabled = false;

        yield return StartCoroutine(Fade(1f));

        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            levelManager.LoadNextLevel();
        }

        yield return StartCoroutine(Fade(0f));

        yield return new WaitForSeconds(0.1f);

        if (doorTriggerCollider != null)
            doorTriggerCollider.enabled = true;
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeCanvasGroup.alpha;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = targetAlpha;
    }
}
