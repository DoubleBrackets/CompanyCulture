using TMPro;
using UnityEngine;

public class TextResizer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textMeshPro;

    [SerializeField]
    private RectTransform _textTransform;

    public void ResizeText()
    {
        if (_textMeshPro == null)
        {
            Debug.LogError("TextMeshPro component is not assigned.");
            return;
        }

        // Calculate the preferred width and height of the text
        float preferredWidth = _textMeshPro.preferredWidth;
        float preferredHeight = _textMeshPro.preferredHeight;

        // Set the size of the RectTransform to fit the text
        _textTransform.sizeDelta = new Vector2(preferredWidth, preferredHeight);
    }
}