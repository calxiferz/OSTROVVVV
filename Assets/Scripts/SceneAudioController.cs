using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneAudioController : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MenuScene") // Replace with your scene name
        {
            AudioManager.Instance.musicSource.Stop();
        }
        else
        {
            AudioManager.Instance.musicSource.Play();
        }
    }
}
