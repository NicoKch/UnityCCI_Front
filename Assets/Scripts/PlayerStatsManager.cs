using UnityEngine;
using UnityEngine.UIElements;
public class PlayerStatsManager : BaseSceneManager
{
    private ListView _listView;
    private ProgressBar _progressBar;
    private readonly ApiService _apiService = GameManager.Instance.GetApiService();
    private Stats _playerStat;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadMenuScene();
        var uiDocument = baseUIDocument.GetComponent<UIDocument>();
        _listView = uiDocument.rootVisualElement.Q<ListView>();
        _listView.style.backgroundColor = new StyleColor(new Color(0.11f, 0.11f, 0.11f)); // #1C1C1C en RGB
        _progressBar = uiDocument.rootVisualElement.Q<ProgressBar>("Niveau");
        StartCoroutine(_apiService.GetUserStats(GameManager.Instance.GetCurrentUser().id,
            stats =>
            {
                _playerStat = stats;
                _progressBar.title = _playerStat.level.ToString();
                PopulateListView( new[]
                {
                    "deathcount : " + _playerStat.deathcount,
                    "playtime : " + _playerStat.playtime,
                    "rank : " + _playerStat.rank,
                    "power : " + _playerStat.power
                });
                
            }, error =>
            {
                Debug.LogError(error);
            }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void PopulateListView(string[] data)
    {
        // Définir la fonction de création d'éléments
        _listView.makeItem = () =>
        {
            // Crée un élément (par exemple un label) pour chaque donnée
            return new Label();
        };

        // Définir la fonction de liaison des données aux éléments
        _listView.bindItem = (element, index) =>
        {
            // Assigner le texte de chaque élément à partir des données
            (element as Label).text = data[index];
        };

        // Définir la taille de la liste
        _listView.itemsSource = data;
        _listView.fixedItemHeight = 30; // Ajustez en fonction de vos besoins
    }
}
