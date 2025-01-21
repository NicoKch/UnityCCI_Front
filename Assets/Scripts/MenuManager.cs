using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuUIDocument; // Assignez MenuUIDocument via l'Inspector
    private Button _statsButton;
    private Button _commentButton;
    private Button _backButton;
    private Button _logoutButton;
    private Button _quitButton;
    private Text _previousScene;
    
    private readonly SceneHandler _sceneHandler = new SceneHandler();
    private void Start()
    {
        // Vérifie que sceneController est assigné
        if (_sceneHandler == null)
        {
            Debug.LogError("SceneController n'est pas assigné dans le MenuController.");
            return;
        }
        
        // Récupérer UIDocument
        var uiDocument = menuUIDocument.GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument n'est pas trouvé sur MenuUIDocument.");
            return;
        }
        
        // Recuperer visualElement
        var root = uiDocument.rootVisualElement;

        // Récupérer les boutons par leurs noms définis dans l'UI Builder
        _statsButton = root.Q<Button>("StatsButton");
        _commentButton = root.Q<Button>("CommentsButton");
        _backButton = root.Q<Button>("BackButton");
        _logoutButton = root.Q<Button>("LogoutButton");
        _quitButton = root.Q<Button>("QuitButton");
        

        // Ajouter les callbacks pour chaque bouton
        _sceneHandler.LoadScene(_statsButton, "PlayerStatsScene");
        _sceneHandler.LoadScene(_commentButton, "CommentScene");
        _sceneHandler.LoadScene(_logoutButton, "LoginScene");
        if (GameManager.Instance.previousScene != null)
        {
            _sceneHandler.LoadScene(_backButton, GameManager.Instance.previousScene);

        }
        _quitButton.clicked += GameManager.QuitGame;
        
    }

    private void Update()
    {
        
    }
}
