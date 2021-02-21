using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    private bool atMainMenu;
    public static GlobalControl Instance;
    private int followers = 0;
    private Vector3 playerPosition;

    public int Followers
    {
        get
        {
            return followers;
        }
        set
        {
            followers = value;
        }
    }
    public Vector3 PlayerPosition
    {
        get
        {
            return playerPosition;
        }
        set
        {
            playerPosition = value;
        }
    }
    public bool AtMainMenu
    {
        get
        {
            return atMainMenu;
        }
        set
        {
            atMainMenu = value;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(followers >=3 )
        {
            // Make win page active
        }
    }
}
