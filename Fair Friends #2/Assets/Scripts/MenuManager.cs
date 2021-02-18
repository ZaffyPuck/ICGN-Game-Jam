using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // public GameManager gm; Thought I would need it for GameState

    /// <summary>
    /// Plays the Game by loading game scene
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
