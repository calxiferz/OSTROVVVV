using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditsScript : MonoBehaviour
{
    public float scrollSpeed =  40f;
    private RectTransform rectTransform;

    private void Start()
    {
        //Get the RectTransform component of the UI element
        rectTransform = GetComponent<RectTransform>();

    }

    private void Update()
    {
        //Move the text upwards over time
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
