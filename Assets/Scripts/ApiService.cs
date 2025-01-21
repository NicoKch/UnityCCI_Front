using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class ApiService
{
    private readonly string API = "http://localhost:8080";

    public IEnumerator GetUserByEmail(string email, Action<User> onSuccess, Action<string> onError)
    {
        string apiUrl = $"{API}/user/{email}";

        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                onError?.Invoke(www.error);
            }
            else
            {
                try
                {
                    User user = JsonUtility.FromJson<User>(www.downloadHandler.text);
                    onSuccess?.Invoke(user);
                }
                catch (Exception ex)
                {
                    onError?.Invoke($"Error parsing response: {ex.Message}");
                }
            }
        }
    }

    public IEnumerator GetUserStats(int userId, Action<Stats> onSuccess, Action<string> onError)
    {
        string apiUrl = $"{API}/user/{userId}/stats";

        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl))
        {
            yield return www.SendWebRequest();

            try
            {
                Stats stats = JsonUtility.FromJson<Stats>(www.downloadHandler.text);
                onSuccess?.Invoke(stats);
            }
            catch (Exception ex)
            {
                onError?.Invoke($"Error parsing response: {ex.Message}");
            }
        }
    }

    public IEnumerator SendComment(Comment comment, Action onSuccess, Action<string> onError)
    {
        string apiUrl = $"{API}/comments";

        // Sérialiser le commentaire en JSON
        string json = JsonUtility.ToJson(comment);

        using (UnityWebRequest www = new UnityWebRequest(apiUrl, "POST"))
        {
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            // Envoyer la requête
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke();
            }
            else
            {
                onError?.Invoke($"Error: {www.error}");
            }
        }
    }
}