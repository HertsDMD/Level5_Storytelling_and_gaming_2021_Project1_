using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_InputManager : MonoBehaviour
{
    public string playerName;
    public GameObject inputField;
    public GameObject inputCanvas;

    public GameObject TextDisplay;

   public void StoreName()
    {
        playerName = inputField.GetComponent<TextMeshProUGUI>().text.ToLower();
        playerName = char.ToUpper(playerName[0]) + playerName.Substring(1);
        TextDisplay.GetComponent<TextMeshProUGUI>().text = "Hello, \n" + playerName + "!";

        StartCoroutine(LoadNextCanvas());
    }

    IEnumerator LoadNextCanvas()
    {
        yield return new WaitForSeconds(2);
        inputCanvas.SetActive(false);   
    }
}
