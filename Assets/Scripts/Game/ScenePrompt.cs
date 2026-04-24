using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScenePrompt : MonoBehaviour
{
    public static ScenePrompt scene1;
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

        SceneManager.LoadSceneAsync("EndScene");
    }




}
