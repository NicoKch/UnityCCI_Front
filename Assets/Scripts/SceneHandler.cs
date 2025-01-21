using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UIElements.Button;

public class SceneHandler
{
    public void LoadScene(Button button,string sceneName)
    {
        if (SceneManager.GetActiveScene().name != "MenuScene")
        {
            GameManager.Instance.previousScene = SceneManager.GetActiveScene().name;
        }
        button.clicked += () => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}