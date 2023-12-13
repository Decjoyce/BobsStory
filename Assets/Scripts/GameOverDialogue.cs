using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Ink.Runtime;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameOverDialogue : MonoBehaviour
{
    public TextAsset inkJSONFile;
    public GameObject Bench;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject faceUI;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    private bool dialoguePlaying;

    public Classmates classmate;
    string typeofClassmate;



    [SerializeField] EventSystem eventSystem;


    // Start is called before the first frame update
    void Start()
    {
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    private void Update()
    {
        if (!dialoguePlaying)
        {
            return;
        }

        if (currentStory.currentChoices.Count == 0 && currentStory.canContinue)
        {
            ContinueStory();
        }
        if (currentStory.currentChoices.Count == 0 && !currentStory.canContinue && Input.GetButtonDown("Submit"))
        {
            //GameManager.instance.GameOver(classmate.classmateType);
        }
    }

    public void EnterDialogueMode(Classmates mate)
    {
        classmate = mate;
        typeofClassmate = classmate.classmateType.classmateType;
        currentStory = new Story(inkJSONFile.text);
        dialoguePlaying = true;
        dialoguePanel.SetActive(true);
        faceUI.SetActive(false);

        //eventSystem.SetSelectedGameObject(choices[0]);

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode()
    {
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        faceUI.SetActive(true);

        classmate.ExitInteraction();
        classmate = null;

    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            StopAllCoroutines();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Need More Choices");
            return;
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);

        if (choiceIndex == 0)
            ContinueStory();
        else
            ExitDialogueMode();
    }
}
