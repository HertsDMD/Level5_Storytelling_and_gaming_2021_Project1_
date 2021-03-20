using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceScript : MonoBehaviour
{
    public GameObject CurrentCanvas;
    public GameObject Option1Canvas;
    public GameObject Option2Canvas;
    public GameObject TextBox;
    public GameObject Choice1Button;
    public GameObject Choice2Button;

    [Header("Option Selection Messages")]
    public string Choice1Message;
    public string Choice2Message;

    int choiceMade;
    bool ChoiceMadeBool;

    [SerializeField]
    int FadeWaitTime = 1;


    public void ChoiceOption1()
    {
        if (TextBox !=null)
        {
             TextBox.GetComponent<TextMeshProUGUI>().text = Choice1Message;
        }
        choiceMade = 1;
    }
    public void ChoiceOption2()
    {
        if (TextBox != null)
        {
           TextBox.GetComponent<TextMeshProUGUI>().text = Choice2Message;
        }
        choiceMade = 2;
    }


    void Update()
    {
        if (choiceMade >= 1)
        {
            Choice1Button.SetActive(false);
            Choice2Button.SetActive(false);
        }
        if (choiceMade == 1 && !ChoiceMadeBool)
        {
            StartCoroutine(UnLoadCurrentCanvas(Option1Canvas));
            ChoiceMadeBool = true;
        }
        if (choiceMade == 2 && !ChoiceMadeBool)
        {
            StartCoroutine(UnLoadCurrentCanvas(Option2Canvas));
            ChoiceMadeBool = true;
        }
    }

    IEnumerator UnLoadCurrentCanvas(GameObject nextCanvas)
    {
        yield return new WaitForSeconds(1);

        float elapsedTime = 0;
        float waitTime = FadeWaitTime;

        while (elapsedTime < waitTime)
        {
            CurrentCanvas.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        nextCanvas.GetComponent<CanvasGroup>().alpha = 0f;
        nextCanvas.SetActive(true);
        StartCoroutine(LoadNextCanvas(nextCanvas));
    }

    IEnumerator LoadNextCanvas(GameObject nextCanvas)
    {
        float elapsedTime = 0;
        float waitTime = FadeWaitTime;

        while (elapsedTime < waitTime)
        {
            nextCanvas.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0, 1, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
             
        CurrentCanvas.SetActive(false);
    }

}
