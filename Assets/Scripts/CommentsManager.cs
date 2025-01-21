using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;
using TextField = UnityEngine.UIElements.TextField;
using Label = UnityEngine.UIElements.Label;

public class CommentsManager : BaseSceneManager
{
    private Button _sendCommentButton;
    private TextField _commentText;
    private readonly ApiService _apiService = GameManager.Instance.GetApiService();
    private Comment _comment;


    private Label _commentLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadMenuScene();
        
        var uiDocument = baseUIDocument.GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("uiDocument == null");
            return;
        }
        var root = uiDocument.rootVisualElement;
        
        _sendCommentButton = root.Q<Button>("SendCommentButton");
        _commentText = root.Q<TextField>("CommentsTextField");
        _commentLabel = root.Q<Label>("CommentsLabel");
        
        
        _sendCommentButton.clicked += () => SubmitComment(new Comment()
        {
            content = _commentText.text,
            author = GameManager.Instance.GetCurrentUser().id
        });
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    void SubmitComment(Comment comment)
    {
        StartCoroutine(_apiService.SendComment(comment, onSuccess: () =>
            {
                Debug.Log("Commentaire envoyé avec succès !");
            },
            onError: (error) =>
            {
                Debug.LogError($"Erreur lors de l'envoie du commentaire : {error}");
            }
        ));
    }
}
