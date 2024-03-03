using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
    public void PlayGame()
    {
        Debug.Log("PlayGame");
        StartCoroutine(Wait());
        SceneManager.LoadScene("Cubos");
    }

    public void OpenOptions()
    {
        // Load the options scene
        Debug.Log("Options");
    }

    public void OpenCredits()
    {
        // Load the credits scene
        Debug.Log("Credits");
    }

    public void OpenRanking()
    {
        // Load the ranking scene
        Debug.Log("Ranking");
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

