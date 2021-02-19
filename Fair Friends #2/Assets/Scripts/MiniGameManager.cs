using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MiniGameManager : MonoBehaviour
{
    private const int numberOfBeans = 17;
    private TMP_InputField input;
    public MiniGameDialogue mgD;
    private int followers;

    private void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<TMP_InputField>();
    }
    private void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(mgD);
        followers = GlobalControl.Instance.Followers;
    }
    public void ReturnToGame()
    {
        //Debug.Log("Changing Scenes");
        SceneManager.LoadScene("FairGrounds");
    }

    public void GetInput(string guess)
    {
        int guessNum = int.Parse(guess);
        input.text = ""; // reset input
        if(guessNum == numberOfBeans)
        {
            string[] newDialogue = new string[3];
            newDialogue[0] = "Congratulations you have won!!!!";
            newDialogue[1] = "I like your moxy kid, you mind if I tag a long for your next game?";
            newDialogue[2] = "Awesome, I can't wait.\n\nYou may exit the game now.";
            mgD.dialogue.sentences = newDialogue;
            followers = 1;
            SavePlayer();

        }
        else if(guessNum < numberOfBeans)
        {
            //higher
            string[] newDialogue = new string[1];
            newDialogue[0] = "ERRRRT, Wrong guess, try going higher!";
            mgD.dialogue.sentences = newDialogue;

        }
        else
        {
            //lower
            string[] newDialogue = new string[1];
            newDialogue[0] = "ERRRRT, Wrong guess, guess lower!";
            mgD.dialogue.sentences = newDialogue;
        }
        // Feedback
        FindObjectOfType<DialogueManager>().StartDialogue(mgD);
    }


    public void SavePlayer()
    {
        GlobalControl.Instance.Followers = followers;
    }
}

