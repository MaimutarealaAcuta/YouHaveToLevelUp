using UnityEngine;
using TMPro;

public class FloatingTextController : MonoBehaviour
{
    [SerializeField]
    private Transform floatingTextParent; // Should be a UI canvas or another UI element
    public GameObject floatingTextPrefab;

    public void CreateFloatingText(string text)
    {
        // Instantiate the floating text as a child of the specified UI parent
        GameObject floatingText = Instantiate(floatingTextPrefab, floatingTextParent);

        //// Set the position relative to the UI parent
        //RectTransform rectTransform = floatingText.GetComponent<RectTransform>();
        //if (rectTransform != null)
        //{
        //    rectTransform.anchoredPosition = position;
        //}

        // Set the text
        TextMeshProUGUI tmp = floatingText.GetComponent<TextMeshProUGUI>();
        if (tmp != null)
        {
            tmp.text = text;
        }
    }
}
