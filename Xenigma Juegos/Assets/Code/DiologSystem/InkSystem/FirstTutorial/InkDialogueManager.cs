using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//Se llama a la libreria de Inky
using Ink.Runtime;

public class InkDialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")] 
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI ActorName;

    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;}

    //Esta será una clase de tipo singletone
    private static InkDialogueManager instance;

    private const string ACTORNAME_TAG = "ActorName";
    private const string ACTORIMAGE_TAG = "ActorImage";
    private const string LAYOUT_TAG = "layout"; 

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Ink Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static InkDialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update() 
    {
        // return si el dialogo esta activo
        if(!dialogueIsPlaying){
            return;
        }  
        // continua al siguiente dialogo
        if(Input.GetKeyDown(KeyCode.Space | KeyCode.F))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            Debug.Log("Se ´presiono el continuar");
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        //Loop Para tomar cada Tag
        foreach (string tag in currentTags)
        {
            String[] splitTag = tag.Split(':');
            if (splitTag.Length !=2)
            {
                Debug.LogError("El tag no tiene el formato necesario para funcionar " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case ACTORNAME_TAG:
                    ActorName.text = tagValue;
                    break;
                case ACTORIMAGE_TAG:
                    break;
                case LAYOUT_TAG:
                    break;
                default:
                    Debug.LogWarning("Tag Came in but not currently being handled " + tag);
                    break;
            }
        }
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
}
