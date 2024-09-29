using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenOverlay : MonoBehaviour
{
    private CanvasGroup canvas;
    public float targetAlpha = 1f;
    public float startAlpha = 0f;
    public float duration = 0.05f;
    // Start is called before the first frame update

    private void Start(){
        GameEventsManager.instance.onGemsCollected += EnableComponent;
        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        StopAllCoroutines();
    }

    private void EnableComponent(int gemsCollected)
    {
        if (gemsCollected > 0)
            gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        canvas = GetComponent<CanvasGroup>();
        StartCoroutine(FadeToAlpha());
    }

    private IEnumerator FadeToAlpha()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            canvas.alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final value is set
        canvas.alpha = targetAlpha;
    }
}
