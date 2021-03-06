﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public string name;
    public Player player;
    private Vector3 playerPosition;
    public TextMeshPro nameText;
    public TextMeshPro dialogueText;
    public GameObject dialogueBubble;
    public Dialogue dialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.transform.position;
        dialogueBubble.SetActive(false);
    }
}
