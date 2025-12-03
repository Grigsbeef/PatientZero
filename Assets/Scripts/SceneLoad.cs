using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// When the scene is played, run some specific functionality
public class SceneLoad : MonoBehaviour
{
    // When scene is loaded and play begins
    public UnityEvent OnLoad = new UnityEvent();

    private void Awake()
    {
        SceneManager.sceneLoaded += PlayEvent;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= PlayEvent;
    }

    private void PlayEvent(Scene scene, LoadSceneMode mode)
    {
        OnLoad.Invoke();
    }
}
