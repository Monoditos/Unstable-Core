using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public GameObject tutorialScreen;

    public GameObject optionsScreen;

    public GameObject creditsScreen;

    public GameObject rankingScreen;
    public IEnumerator Tutorial(int seconds)
    {
        Debug.Log("tutorial shown");
        tutorialScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(seconds);
        Debug.Log("tutorial hidden");
        //tutorialScreen.SetActive(false);
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
        Debug.Log("Open Options");
        optionsScreen.SetActive(true);

    }

    public void CloseOptions()
    {
        // Load the options scene
        Debug.Log("Close Options");
        optionsScreen.SetActive(false);

    }

    public void OpenCredits()
    {
        Debug.Log("Open Credits");
        creditsScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        Debug.Log("Close Credits");
        creditsScreen.SetActive(false);
    }

    public void OpenRanking()
    {
        Debug.Log("Open Ranking");
        rankingScreen.SetActive(true);
    }

    public void CloseRanking()
    {
        // Load the ranking scene
        Debug.Log("Close Ranking");
        rankingScreen.SetActive(false);
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

