using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    int mouseclick = 5;
    public Text movesLeftText;

    MoveObject moveObjetScript;
    bool triggerGameOver;
    MoveObject moveObject;

    // Start is called before the first frame update
    void Start()
    {
        moveObject = FindObjectOfType<MoveObject>();
        moveObject.MouseClickEvent += DeductClickCount;

        movesLeftText.text = "Moves Left: " + mouseclick.ToString();
    }

    private void DeductClickCount()
    {
        mouseclick--;
        movesLeftText.text = "Moves Left: " + mouseclick.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseclick <=0 && !triggerGameOver)
        {
            if (moveObject != null)
            {
                moveObject.MouseClickEvent -= DeductClickCount;
                Destroy(moveObject.gameObject);
                movesLeftText.text = "Out Of Moves!";
            }
            triggerGameOver = true;
        }
    }
}
