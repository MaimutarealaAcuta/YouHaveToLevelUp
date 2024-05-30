using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroyTime = 0.5f;
    public float xOffset;
    public float yOffset;
    public Vector3 randomizeIntensity = new Vector3(1, 0.5f, 0);

    void Start()
    {
        Destroy(gameObject, destroyTime);

        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.localPosition += new Vector3(Random.Range(-xOffset, xOffset), Random.Range(-yOffset, yOffset), 0);
            rectTransform.localPosition += new Vector3(
                Random.Range(-randomizeIntensity.x, randomizeIntensity.x),
                Random.Range(-randomizeIntensity.y, randomizeIntensity.y),
                Random.Range(-randomizeIntensity.z, randomizeIntensity.z)
            );

            rectTransform.rotation = Quaternion.Euler(0, 0, Random.Range(-15, 15));
        }
    }
}
