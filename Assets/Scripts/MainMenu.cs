using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;

    public IEnumerator FadeIn()
    {
        panel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        while (panel.GetComponent<Image>().color.a < 255){
            panel.GetComponent<Image>().color = new Color(0, 0, 0, panel.GetComponent<Image>().color.a + 1);
            yield return new WaitForSeconds(0.01f);
        }
        //panel.gameObject.SetActive(false);
        //SceneManager.LoadScene("Cubos");
    }
    public void PlayGame()
    {
        Debug.Log("PlayGame");
        panel.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
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

