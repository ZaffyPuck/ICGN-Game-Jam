using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JellyBeanGameManager : MonoBehaviour
{
    private int numberOfBeans;
    private TMP_InputField input;
    public MiniGameDialogue mgD;

    private void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<TMP_InputField>();
    }
    private void Start()
    {
        numberOfBeans = Random.Range(0, 20);
        FindObjectOfType<DialogueManager>().StartDialogue(mgD);
    }
    public void ReturnToGame()
    {
        //Debug.Log("Changing Scenes");
        SceneManager.LoadScene("FairGrounds");
    }

    public void GetInput(string guess)
    {
        int guessNum;
        bool guessTest = int.TryParse(guess, out guessNum);
        input.text = ""; // reset input
        if (guessTest)
        {
            if (guessNum == numberOfBeans)
            {
                string[] newDialogue = new string[3];
                newDialogue[0] = "Congratulations you have won!!!!\n\nYou gained one follower, ME!";
                newDialogue[1] = "I like your moxy, would you mind if I tag a long for your next game?";
                newDialogue[2] = "Awesome, I can't wait. Don't worry, I will fly over to your next game.\n\nYou may exit the game now.";
                mgD.dialogue.sentences = newDialogue;
                GlobalControl.Instance.Followers++;

            }
            else if (guessNum < numberOfBeans)
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
        }
        else
        {
            input.text = ""; // reset input            mgD.dialogue.sentences[0] = "Please input a numer between 1 and 20!";
        }

        // Feedback
        FindObjectOfType<DialogueManager>().StartDialogue(mgD);
    }
}

