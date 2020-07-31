using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;

        sceneIndex++;
        
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadStartScene()
    {
        Reset();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Reset()
    {
        FindObjectOfType<GameState>().Reset();
    }
}
