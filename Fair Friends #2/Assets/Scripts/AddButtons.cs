using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject button;

    private void Awake()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject tempButton = Instantiate(button);
            tempButton.name = "" + i;
            //tempButton.name = "CardButton" + (i+1);
            tempButton.transform.SetParent(puzzleField, false);
            //tempButton.transform.parent = puzzleField;
        }
    }
}
