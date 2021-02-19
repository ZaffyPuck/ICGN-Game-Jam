using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    private const int numberOfBeans = 17;
    private string playerGuess;
    private InputField input;

    private void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }
    public void ReturnToGame()
    {
        //Debug.Log("Changing Scenes");
        SceneManager.LoadScene("FairGrounds");
    }

    public void GetInput(string guess)
    {
        input.text = "";
        playerGuess = guess;
        Debug.Log(guess);
    }
}
