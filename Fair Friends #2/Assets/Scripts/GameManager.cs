using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState
    {
        FreeRoam,
        Market1,
        Market2,
        Market3,
        Market4,
        Market5,
        Menu
    }

    private GameState currentState;
    public GameObject player;
    private Player playerScript;

    public GameObject zebra_NPC;

    // Visual
    public Camera[] cameras;
    private int currentCameraIndex;
    void Start()
    {
        currentState = GameState.FreeRoam;
        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        
    }
}
