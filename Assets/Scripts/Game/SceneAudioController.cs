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
            AudioManager1.Instance.musicSource.Stop();
        }
        else
        {
            AudioManager1.Instance.musicSource.Play();
        }
    }
}
