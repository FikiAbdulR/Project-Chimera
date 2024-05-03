using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance;

    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.1f;
    public AnimationCurve shakeFalloff;

    private Vector3 originalPosition;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ShakeScreen()
    {
        originalPosition = transform.localPosition;
        StartCoroutine(DoShake());
    }

    private IEnumerator DoShake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float falloff = shakeFalloff.Evaluate(elapsedTime / shakeDuration);
            Vector3 offset = Random.insideUnitSphere * shakeIntensity * falloff;
            transform.localPosition = originalPosition + offset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition; // Reset position after shake
    }
}

