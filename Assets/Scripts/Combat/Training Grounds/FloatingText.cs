using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroyTime = 0.5f;
    public Vector3 offset = new Vector3(0, 2, 0);
    public Vector3 randomizeIntensity = new Vector3(1, 0.5f, 0);

    void Start()
    {
        Destroy(gameObject, destroyTime);

        transform.localPosition += offset;
        transform.localPosition += new Vector3(
            Random.Range(-randomizeIntensity.x, randomizeIntensity.x),
            Random.Range(-randomizeIntensity.y, randomizeIntensity.y),
            Random.Range(-randomizeIntensity.z, randomizeIntensity.z)
        );

        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-15, 15));
    }
}
