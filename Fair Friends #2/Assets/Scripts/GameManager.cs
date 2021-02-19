using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Fields
    /// <summary>
    /// Game States
    /// </summary>
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
    // Players
    public GameObject player;
    private Player playerScript;
    // NPCs
    public GameObject npcVisability;
    public NPC[] npcs;
    // Stands
    public GameObject standVisability;
    public Stand[] stands;
    // UI
    public GameObject pauseMenuUI;
    void Start()
    {
        currentState = GameState.FreeRoam;
        playerScript = player.GetComponent<Player>();
        player.SetActive(true);
        pauseMenuUI.SetActive(false);
        npcVisability.SetActive(true);
        standVisability.SetActive(true);
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
                //player.SetActive(true); 
                // Update Dialogue
                for(int i = 0; i < npcs.Length; i++)
                {
                    detectNPCDialogue(playerScript, npcs[i]);
                    if(i < stands.Length)
                    {
                        detectStand(playerScript, stands[i]);
                    }
                }
                // Menu
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    //player.SetActive(false); //Prevents character from moving/updating in menu
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

    private void detectNPCDialogue(Player player, NPC npc)
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 npcPosition = npc.transform.position;
        if (playerPosition.x > (npcPosition.x - 5) &&
            playerPosition.x < (npcPosition.x + 5) &&
            playerPosition.y > (npcPosition.y - 5) &&
            playerPosition.y < (npcPosition.y + 5))
        {
            if (!npc.dialogueBubble.activeSelf)
            {
                npc.dialogueBubble.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(npc);
            }
        }
        else
        {
            npc.dialogueBubble.SetActive(false);
        }
    }
    private void detectStand(Player player, Stand stand)
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 standPosition = stand.transform.position;
        if (playerPosition.x > (standPosition.x - 5) &&
            playerPosition.x < (standPosition.x + 5) &&
            playerPosition.y > (standPosition.y - 5) &&
            playerPosition.y < (standPosition.y + 5) &&
            Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(stand.gameScene);
        }
    }
}
