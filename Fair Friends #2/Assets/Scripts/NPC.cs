using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string name;
    private float x, y;
    private const float z = -1;
    public Vector3 pos;
    public Player player;
    private Vector3 playerPosition;
    public Dialogue dialogue;
    public GameObject chatBubble;
    // Start is called before the first frame update
    void Start()
    {
        x = 10;
        y = 10;
        pos = new Vector3(x, y, z);
        transform.position = pos;

        playerPosition = player.pos;
        chatBubble.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        playerPosition = player.pos;
        if (playerPosition.x > (pos.x - 5) &&
            playerPosition.x < (pos.x + 5) &&
            playerPosition.y > (pos.y - 5) &&
            playerPosition.y < (pos.y + 5) &&
            Input.GetKeyDown(KeyCode.Return))
        {
            chatBubble.SetActive(true);
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, name);
    }

}
