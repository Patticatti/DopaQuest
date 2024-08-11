using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RewardsTextAnimation : MonoBehaviour
{
    private HorizontalLayoutGroup layoutGroup;
    public float startSpacing = -50f;
    public float endSpacing = 12f;
    public float duration = 0.05f;

    private void OnEnable()
    {
        layoutGroup = GetComponent<HorizontalLayoutGroup>();
        StartCoroutine(LerpSpacing());
    }

    private IEnumerator LerpSpacing()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            layoutGroup.spacing = Mathf.Lerp(startSpacing, endSpacing, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final value is set
        layoutGroup.spacing = endSpacing;
    }
}
