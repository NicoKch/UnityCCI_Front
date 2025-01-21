using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingSceneManager : MonoBehaviour
{
    private void Start()
    {
        // Attendre 2 secondes avant de charger la scène LoginScene
        StartCoroutine(LoadLoginSceneWithDelay());
    }

    private IEnumerator LoadLoginSceneWithDelay()
    {
        // Attendre 2 secondes
        yield return new WaitForSeconds(2f);

        // Charger la scène LoginScene après 2 secondes
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoginScene");
    }
}