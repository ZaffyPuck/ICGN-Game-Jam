using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchingGameManager : MonoBehaviour
{
    // Fields
    public GameObject winScreen;
    public MiniGameDialogue mgD;
    [SerializeField]
    private Sprite backsideImage;
    public Sprite[] puzzles;
    public List<Sprite> puzzleSprites = new List<Sprite>();
    public List<Button> buttons = new List<Button>();
    private bool firstGuess, secondGuess;
    private int numGuesses;
    private int numCorrectGuesses;
    private int gameGuesses;
    private string firstGuessPuzzle, secondGuessPuzzle;
    private int firstGuessIndex, secondGuessIndex;
    public AudioSource matchSound;
    public AudioSource click;

    private void Awake()
    {
        GlobalControl.Instance.AtMainMenu = false;
        puzzles = Resources.LoadAll<Sprite>("Sprites");
        winScreen.SetActive(false);
    }

    private void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(mgD);
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(puzzleSprites);
        gameGuesses = puzzleSprites.Count / 2; // 5
    }

    private void GetButtons()
    {
        GameObject[] tempButtonCollection = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for(int i = 0; i < tempButtonCollection.Length; i++)
        {
            buttons.Add(tempButtonCollection[i].GetComponent<Button>());
            buttons[i].image.sprite = backsideImage;
        }
    }
    private void AddGamePuzzles()
    {
        int numOfButtons = buttons.Count;
        int index = 0;

        for(int i = 0; i < numOfButtons; i++)
        {
            if(index == numOfButtons / 2)
            {
                index = 0;
            }
            puzzleSprites.Add(puzzles[index]);
            index++;
        }
    }
    private void AddListeners()
    {
        foreach(Button button in buttons)
        {
            button.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void PickAPuzzle()
    {
        if(!firstGuess)
        {
            firstGuess = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = puzzleSprites[firstGuessIndex].name;

            buttons[firstGuessIndex].image.sprite = puzzleSprites[firstGuessIndex];
        }
        else if(!secondGuess)
        {
            secondGuess = true;

            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = puzzleSprites[secondGuessIndex].name;

            buttons[secondGuessIndex].image.sprite = puzzleSprites[secondGuessIndex];

            numGuesses++;

            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }

    private IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            matchSound.Play();
            yield return new WaitForSeconds(.5f);

            buttons[firstGuessIndex].interactable = false;
            buttons[secondGuessIndex].interactable = false;

            buttons[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            buttons[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfGameIsFinished();
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            buttons[firstGuessIndex].image.sprite = backsideImage;
            buttons[secondGuessIndex].image.sprite = backsideImage;
        }

        yield return new WaitForSeconds(.5f);

        firstGuess = secondGuess = false;
    }

    private void CheckIfGameIsFinished()
    {
        numCorrectGuesses++;

        if(numCorrectGuesses == gameGuesses)
        {
            click.Play();
            winScreen.SetActive(true);
            GlobalControl.Instance.Followers++;
        }
    }

    private void Shuffle(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite tempSprite = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = tempSprite;
        }
    }

    public void ReturnToGame()
    {
        SceneManager.LoadScene("FairGrounds");
    }
}
