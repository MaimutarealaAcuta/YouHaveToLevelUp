using UnityEngine;
using TMPro;

public class FloatingTextController : MonoBehaviour
{
    public GameObject floatingTextPrefab;

    public void CreateFloatingText(Vector3 position, string text)
    {
        GameObject floatingText = Instantiate(floatingTextPrefab, position, Quaternion.identity, transform);
        TextMeshPro tmp = floatingText.GetComponent<TextMeshPro>();
        tmp.text = text;
    }
}
