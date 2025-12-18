using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void OnQuitButtonClicked()
    {
        //Only works in the build of the game.
        Application.Quit();
    }
}
