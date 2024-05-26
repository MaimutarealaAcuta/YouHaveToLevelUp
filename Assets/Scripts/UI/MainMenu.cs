using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject highScorePanel;

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
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void OpenHighScores()
    {
        highScorePanel.SetActive(true);
    }

    public void CloseHighScores()
    {
        highScorePanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
