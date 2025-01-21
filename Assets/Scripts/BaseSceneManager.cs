using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class BaseSceneManager : MonoBehaviour 
{
    [SerializeField] protected GameObject baseUIDocument; 
    private readonly SceneHandler _sceneHandler = new SceneHandler();
    private Button _menuButton;
    
    protected void LoadMenuScene()
    {
        var uiDocument = baseUIDocument.GetComponent<UIDocument>();
        // Récupérer le rootVisualElement depuis le UIDocument
        var root = uiDocument.rootVisualElement;
        
        _menuButton = root.Q<Button>("MenuButton");
        
        _sceneHandler.LoadScene(_menuButton, "MenuScene");
    }
}