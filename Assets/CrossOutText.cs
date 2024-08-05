using System.Collections;
using UnityEngine;
using TMPro;

public class CrossOutText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private LineRenderer lineRenderer;
    private float duration = 0.8f;
    private float lineWidth = 2.0f;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        lineRenderer = GetComponent<LineRenderer>();
        // Ensure the line renderer is set up
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = 2;
        
        // Start the animation
    }

    public void StartAnimateCrossOut()
    {
        StartCoroutine(AnimateCrossOut());
    }

    private IEnumerator AnimateCrossOut()
    {
        Vector3[] corners = new Vector3[4];
        text.rectTransform.GetWorldCorners(corners);

        Vector3 start = corners[1]; // Top-left corner
        Vector3 end = corners[2]; // Top-right corner

        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            Vector3 currentEnd = Vector3.Lerp(start, end, t);
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, currentEnd);
            yield return null;
        }

        // Ensure the line reaches the end
        lineRenderer.SetPosition(1, end);
    }
}
