using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void playGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1);
    }

    public void menuGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(2);
    }

    public void reTry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1);
    }

    public void Next()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}