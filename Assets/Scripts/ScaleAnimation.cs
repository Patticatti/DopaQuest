using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    public Vector3 startScale = new Vector3(1.3f, 1.3f, 1.3f);
    public Vector3 endScale = new Vector3(1f, 1f, 1f);
    public float duration = 0.1f;

    private void OnEnable()
    {
        // StartCoroutine(LerpScale(endScale, startScale, 0.04f));
        StartCoroutine(LerpScale(startScale, endScale, duration));
    }

    private IEnumerator LerpScale(Vector3 start, Vector3 end, float time)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;
            transform.localScale = Vector3.Lerp(start, end, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final scale is set
        transform.localScale = end;
    }
}
