using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
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
}
