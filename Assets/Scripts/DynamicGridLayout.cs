using UnityEngine;
using TMPro;

public class DynamicGridLayout : MonoBehaviour
{
    [SerializeField] GameObject group16x9, group9x16, blackPanel;
    [SerializeField] private TextMeshProUGUI text;

    void Update() => AdjustLayout();

    void AdjustLayout()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
        
        if (aspectRatio > 1.0f)
        {
            if (text) text.fontSizeMax = 74;
            if (blackPanel) blackPanel.GetComponent<RectTransform>().localScale = new Vector2 (0.6f, 0.6f);
            if (group16x9 && group9x16)
            {
                group16x9.SetActive(true);
                group9x16.SetActive(false);
            }
        }
        else
        {
            if (blackPanel) blackPanel.GetComponent<RectTransform>().localScale = new Vector2 (0.95f, 0.95f);
            if (text) text.fontSizeMax = 100;
            if (group16x9 && group9x16)
            {
                group16x9.SetActive(false);
                group9x16.SetActive(true);
            }
        }
    }
}