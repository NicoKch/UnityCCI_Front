using System;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class LoginManager : MonoBehaviour
{
    
    [SerializeField] private GameObject loginUIDocument; // Assignez MenuUIDocument via l'Inspector
    private Button _loginButton;
    private TextField _mailInputField;
    private TextField _passwordInputField;
    private ApiService _apiService = GameManager.Instance.GetApiService();
    
    private string _apiUrl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (loginUIDocument == null)
        {
            Debug.LogError("LoginUIDocument n'est pas assigné !");
            return;
        }
        var uiDocument = loginUIDocument.GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;
        
        _loginButton = root.Q<Button>("ConnexionButton");
        _mailInputField = root.Q<TextField>("EmailTextField");
        _passwordInputField = root.Q<TextField>("PasswordTextField");
        if (_loginButton == null)
        {
            Debug.LogError("Bouton 'connexionButton' introuvable !");
            return;
        }
        _loginButton.clicked += () => Login(_mailInputField.text, _passwordInputField.text);
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Login(String email, String password)
    {
        StartCoroutine(
            _apiService.GetUserByEmail(
                email,
                user =>
                {
                    if (password != user.password)
                    {
                        Debug.LogError("Mot de passe incorrect !");
                        return;
                    }

                    Debug.Log($"Bienvenue {user.name} !");
                    GameManager.Instance.SetCurrentUser(user);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
                },
                error =>
                {
                    Debug.LogError($"Erreur lors de la connexion : {error}");
                }
            )
        );
    }

    // public IEnumerator GetRequest(string apiUrl, string password)
    // {
    //     using (UnityWebRequest www = UnityWebRequest.Get(apiUrl))
    //     {
    //         yield return www.SendWebRequest();
    //         if (www.result != UnityWebRequest.Result.Success)
    //         {
    //             Debug.LogError(www.error);
    //         }
    //         User user = JsonUtility.FromJson<User>(www.downloadHandler.text);
    //         Debug.Log(www.downloadHandler.text);
    //         Debug.Log(user.name);
    //         if (password != user.password)
    //         {
    //             throw new Exception("mot de passe incorrect");
    //         }
    //
    //         SceneManager.LoadScene("MenuScene");
    //     };
    // }
}