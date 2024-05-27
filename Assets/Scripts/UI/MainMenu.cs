using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject highScorePanel;

    private void Start()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
        highScorePanel.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("SavedGame"))
        {
            SceneManager.LoadScene("MainGameScene");
        }
        else
        {
            Debug.Log("No saved game found!");
        }
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void OpenHighScores()
    {
        highScorePanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void CloseHighScores()
    {
        highScorePanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
