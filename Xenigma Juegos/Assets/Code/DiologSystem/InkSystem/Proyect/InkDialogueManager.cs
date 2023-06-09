using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//Se llama a la libreria de Inky
using Ink.Runtime;
using Unity.VisualScripting;

public class InkDialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")] 
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI actorName;
    [SerializeField] private Animator actorImageAnimator;
    [SerializeField] private Animator layoutAnimator;
    

    [Header("Scene Controll")]
    private SceneTransition _sceneTransition;
    private Scene currentScene;
    private string sceneName;
    [HideInInspector]
    public bool endStory { get; private set; }

    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;}

    //Esta será una clase de tipo singletone
    private static InkDialogueManager instance;

    private const string ACTORNAME_TAG = "ActorName";
    private const string ACTORIMAGE_TAG = "ActorImage";
    private const string LAYOUT_TAG = "layout";
    private const string SCENE_TAG = "Scene";

    private void Awake()
    {
        _sceneTransition = new SceneTransition();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Found more than one Ink Dialogue Manager in the scene");
            Destroy(gameObject);
        }
        
    }

    public static InkDialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        endStory = false;
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        
        
    }

    private void Update() 
    {
        currentScene = SceneManager.GetActiveScene();
        // return si el dialogo esta activo
        if(!dialogueIsPlaying){
            return;
        }  
        // continua al siguiente dialogo
        if(Input.GetKeyDown(KeyCode.Space))
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
            //Debug.Log("Se ´presiono el continuar");
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
                    actorName.text = tagValue;
                    break;
                case ACTORIMAGE_TAG:
                    actorImageAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                case SCENE_TAG:
                    Debug.Log("Termino la cinematica de " + actorName.text + "Pasa a la siguiente escena para prender el objeto necesario");
                    break;
                default:
                    Debug.LogWarning("Tag Came in but not currently being handled " + tag);
                    break;
            }
        }
    }

    public IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        endStory = true;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        sceneName = currentScene.name;
        if (sceneName == "02PreguntasDelPasado")
        {
            yield return null;
        }
        else
        {
            StartCoroutine(GoToMyScene("02PreguntasDelPasado"));    
        }

        
    }

    private IEnumerator GoToMyScene(String SceneName)
    {
        yield return new WaitForSeconds(1f);
        
        _sceneTransition.SceneToLoad = SceneName;
        _sceneTransition.LoadScene();
    }
    
}
