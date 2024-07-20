using UnityEngine;
using TMPro;

public class DynamicGridLayout : MonoBehaviour
{
    public GameObject group16x9, group9x16, button;
    public TextMeshProUGUI textMeshPro;

    void Update() => AdjustLayout();

    void AdjustLayout()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
        
        if (aspectRatio > 1.0f)
        {
            textMeshPro.fontSizeMax = 74;
            //button.GetComponent<RectTransform>().sizeDelta = new Vector2 (800, 180);
            //button.GetComponent<RectTransform>().localPosition = new Vector2 (0, -190);
            button.GetComponent<RectTransform>().offsetMin = new Vector2 (20, 20);
            group16x9.SetActive(true);
            group9x16.SetActive(false);
        }
        else
        {
            textMeshPro.fontSizeMax = 100;
            //button.GetComponent<RectTransform>().sizeDelta = new Vector2 (1600, 300);
            //button.GetComponent<RectTransform>().localPosition = new Vector2 (0, -500);
            button.GetComponent<RectTransform>().offsetMin = new Vector2 (250, 100);
            group16x9.SetActive(false);
            group9x16.SetActive(true);
        }
    }
}