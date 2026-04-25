using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScenePrompt : MonoBehaviour
{
    public static ScenePrompt scene1;
    [SerializeField] private string transitionTo;
    public TMP_InputField inputField;

    public string player_prompt;

    private void Awake()
    {
        if (scene1 == null)
        {
            scene1 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerPrompt()
    {
        player_prompt = inputField.text;

        GameManager.Instance.transitionedFromScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(transitionTo);
    }




}
