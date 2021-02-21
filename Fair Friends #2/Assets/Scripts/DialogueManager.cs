using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Fields
    private Queue<string> sentences;
    public GameObject IntroDialogue;
    public TMP_Text IntroButtonText;
    public AudioSource popUpSound;
    public AudioSource clickSound;

    void Awake()
    {
        sentences = new Queue<string>();
        if (IntroDialogue && GlobalControl.Instance.AtMainMenu)
        {
            IntroDialogue.SetActive(true);
        }
    }

    public void StartDialogue(NPC npc)
    {
        popUpSound.Play();
        Debug.Log("Starting conversation with " + npc.name);
        TextMeshPro nameText = npc.nameText;
        TextMeshPro dialogueText = npc.dialogueText;
        nameText.text = npc.name;

        sentences.Clear();

        foreach(string sentence in npc.dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(npc);
    }
    public void DisplayNextSentence(NPC npc)
    {
        if(sentences.Count == 0)
        {
            EndDialogue(npc);
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, npc));
    }
    IEnumerator TypeSentence (string sentence, NPC npc)
    {
        WaitForSeconds wait = new WaitForSeconds(1/60f);
        npc.dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            npc.dialogueText.text += letter;
            yield return wait;
        }
    }
    void EndDialogue(NPC npc)
    {
        npc.dialogueBubble.SetActive(false);
    }

    // For MiniGames
    public void StartDialogue(MiniGameDialogue mgD)
    {
        popUpSound.Play();
        Debug.Log("Starting conversation with " + mgD.name);
        TextMeshPro nameText = mgD.nameText;
        TextMeshPro dialogueText = mgD.dialogueText;
        nameText.text = mgD.name;

        sentences.Clear();

        foreach (string sentence in mgD.dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(mgD);
    }
    public void DisplayNextSentence(MiniGameDialogue mgD)
    {
        if (sentences.Count == 0)
        {
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, mgD));
    }
    IEnumerator TypeSentence(string sentence, MiniGameDialogue mgD)
    {
        WaitForSeconds wait = new WaitForSeconds(1 / 60f);
        mgD.dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            mgD.dialogueText.text += letter;
            yield return wait;
        }
    }

    // For Player
    public void StartDialogue(PlayerDialogue pd)
    {
        clickSound.Play();
        TextMeshPro dialogueText = pd.playerDialogueText;

        sentences.Clear();

        foreach (string sentence in pd.dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(pd);
    }
    public void DisplayNextSentence(PlayerDialogue pd)
    {
        Debug.Log("Clicked");
        if (sentences.Count == 1)
        {
            //change button to say play
            IntroButtonText.text = "Play";
        }
        else if (sentences.Count == 0)
        {
            //close dialogue window
            IntroDialogue.SetActive(false);
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, pd));
    }
    IEnumerator TypeSentence(string sentence, PlayerDialogue pd)
    {
        WaitForSeconds wait = new WaitForSeconds(1 / 60f);
        pd.playerDialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            pd.playerDialogueText.text += letter;
            yield return wait;
        }
    }
}
