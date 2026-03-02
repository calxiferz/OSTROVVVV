using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int collectibleCount = 0;
    public TMP_Text collectibleText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        collectibleText.text = $"Collectibles: {collectibleCount}";  //dollar sign lets you use variables within a string
    
    }

    public void AddCollectible()
    {
        collectibleCount++;
        UpdateCollectibleUI();
    }

    private void UpdateCollectibleUI()
    {
        if (collectibleText != null)
        {
            collectibleText.text = $"Collectibles {collectibleCount}";
        }
    }
}
