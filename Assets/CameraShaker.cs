using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public float shakeDuration = 0.1f;
    public float shakeAmount = 3f;
    public float decreaseFactor = 2.0f;

    private Vector3 originalPosition;
    private float currentShakeDuration;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (currentShakeDuration > 0)
        {
            // Shake the camera
            Vector3 shakeOffset = Random.insideUnitSphere * shakeAmount;
            transform.localPosition = originalPosition + shakeOffset;

            // Decrease the shake duration over time
            currentShakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            // Reset the camera position
            transform.localPosition = originalPosition;
        }
    }

    public void ShakeCamera()
    {
        currentShakeDuration = shakeDuration;
        Debug.Log("s");
    }
}
