using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    enum GameState
    {
        Menu,
        FreeRoam,
        Market1,
        Market2,
        Market3,
        Market4,
        Market5,
        PauseMenu
    }

    private GameState currentState;
    private GameState previousState;
    public GameObject player;
    private Player playerScript;

    public GameObject zebra_NPC;
    public Camera camera;
    public GameObject pauseMenuUI;
    void Start()
    {
        currentState = GameState.FreeRoam;
        playerScript = player.GetComponent<Player>();
        player.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        switch(currentState)
        {
            case GameState.Menu:
                previousState = GameState.Menu;
                break;
            case GameState.FreeRoam:
                previousState = GameState.FreeRoam;
                // Update objects
                player.SetActive(true); 
                updateCamera(player.transform.position);
                // Menu
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    player.SetActive(false); //Prevents character from moving/updating in menu
                    PauseGame();
                }
                // Get to other game modes (markets)
                break;
            case GameState.Market1:
                previousState = GameState.Market1;
                // Menu
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseGame();
                }
                break;
            case GameState.Market2:
                previousState = GameState.Market2;
                // Menu
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseGame();
                }
                break;
            case GameState.Market3:
                previousState = GameState.Market3;
                // Menu
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseGame();
                }
                break;
            case GameState.Market4:
                previousState = GameState.Market4;
                // Menu
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseGame();
                }
                break;
            case GameState.Market5:
                previousState = GameState.Market5;
                // Menu
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseGame();
                }
                break;
            case GameState.PauseMenu:
                pauseMenuUI.SetActive(true);
                //Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.Escape) ) // Resume Game
                {
                    ResumeGame();
                }
                break;
        }
        
    }

    private void updateCamera(Vector3 playerPos)
    {
        Vector3 cameraPos = new Vector3(playerPos.x, playerPos.y, -2);
        camera.transform.position = cameraPos;
    }


    // -------- Event Handelers / Methods -------- //
    void PauseGame()
    {
        currentState = GameState.PauseMenu;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        currentState = previousState;
    }

    public void LoadMenu()
    {
        //Time.timeScale = 1f;
        currentState = GameState.Menu;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
