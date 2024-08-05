using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAnimation : MonoBehaviour
{
    public Transform targetTransform;

    public float moveDuration = 0.25f;
    public float targetScale = 1.2f;
    public float initialScale = 0.01f;
    public float moveDistance = 80f;
    public float scaleBackDuration = 0.15f;
    public float moveToTargetDuration = 0.6f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private Vector3 originalScale;
    private Vector3 targetScaleVector;
    private Vector3 finalScale;

    private void Start()
    {
        targetTransform = GameObject.FindWithTag("GemCounter").transform;
        Vector2 randomDirection2D = Random.insideUnitCircle.normalized * moveDistance;
        Vector3 randomDirection3D = new Vector3(randomDirection2D.x, randomDirection2D.y, 0);
        targetPosition = transform.position + randomDirection3D;

        // Store original position and scale
        originalPosition = transform.position;
        originalScale = Vector3.one * initialScale;
        targetScaleVector = Vector3.one * targetScale;
        finalScale = Vector3.one; // Target scale back to 1

        // Start at the initial scale
        transform.localScale = originalScale;

        // Start the movement and scaling coroutine
        StartCoroutine(MoveAndScaleOverTime());
    }

    private IEnumerator MoveAndScaleOverTime()
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            // Lerp position
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);

            // Lerp scale
            transform.localScale = Vector3.Lerp(originalScale, targetScaleVector, elapsedTime / moveDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final position and scale are set
        transform.position = targetPosition;
        transform.localScale = targetScaleVector;

        // Start scaling back coroutine
        StartCoroutine(ScaleBackOverTime());
    }

    private IEnumerator ScaleBackOverTime()
    {
        float elapsedTime = 0f;
        Vector3 currentScale = transform.localScale;

        while (elapsedTime < scaleBackDuration)
        {
            // Lerp scale back to 1
            transform.localScale = Vector3.Lerp(currentScale, finalScale, elapsedTime / scaleBackDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final scale is set
        transform.localScale = finalScale;
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = targetTransform.position;

        while (elapsedTime < moveToTargetDuration)
        {
            // Calculate the time fraction that has passed
            float t = elapsedTime / moveToTargetDuration;

            // Apply an ease-in curve to the fraction
            t = Mathf.Pow(t, 3);

            // Lerp the position based on the eased time fraction
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            transform.localScale = Vector3.Lerp(finalScale, originalScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set
        transform.position = endPosition;

        // Destroy the game object once it reaches the target
        Destroy(gameObject);
    }

}
