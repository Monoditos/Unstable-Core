using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public GameObject tutorialScreen;
    public IEnumerator Tutorial(int seconds)
    {
        Debug.Log("tutorial shown");
        tutorialScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(seconds);
        Debug.Log("tutorial hidden");
        tutorialScreen.SetActive(false);
        SceneManager.LoadScene("Cubos");
    }
    public void PlayGame()
    {
        Debug.Log("PlayGame");
        StartCoroutine(Tutorial(10)) ;
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

