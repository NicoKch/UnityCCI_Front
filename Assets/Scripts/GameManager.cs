using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instance privée
    private static GameManager _instance;
    private static User _currentUser;
    private readonly ApiService _apiService = new ApiService();


    // Propriété publique pour accéder à l'instance
    public static GameManager Instance
    {
        get
        {
            // Vérifie que l'instance existe avant de la retourner
            if (_instance == null)
            {
                Debug.LogError("GameManager is not initialized!");
            }
            return _instance;
        }
    }

    public string previousScene;
    
    private void Awake()
    {
        // Assure-toi qu'une seule instance existe
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Préserver cet objet entre les scènes
        }
        else
        {
            {
                Debug.LogWarning("Une instance de GameManager existe déjà. Suppression de l'objet en double.");
                Destroy(gameObject); // Supprimer les doublons
                return; // Assurez-vous que le reste du code ne s'exécute pas
            }
        }
    }

    private void Start()
    {
    }
    
    // Update is called once per frame
    private void Update()
    {
        
    }

    public User GetCurrentUser()
    {
        return _currentUser;
    }

    public void SetCurrentUser(User user)
    {
        _currentUser = user;
    }

    public ApiService GetApiService()
    {
        return _apiService;
    }
    
    public static void QuitGame()
    {
        Debug.Log("Quitter le jeu");
        Application.Quit();
    }
    
    
}
