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
        if (scene.name == "Level0")
        {
            AudioManager.Instance.musicSource.Stop();
        }
        else
        {
            AudioManager.Instance.musicSource.Play();
        }
        if (scene.name == "Level1")
        {
            AudioManager.Instance.musicSource.Stop();
        }
        else
        {
            AudioManager.Instance.musicSource.Play();
        }
        if (scene.name == "Level2")
        {
            AudioManager.Instance.musicSource.Stop();
        }
        else
        {
            AudioManager.Instance.musicSource.Play();
        }
    }
}
