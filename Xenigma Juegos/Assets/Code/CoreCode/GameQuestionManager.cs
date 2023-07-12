using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameQuestionManager : MonoBehaviour
{
    [Header("Game Trigger")] 
    [SerializeField] private GameObject[] questionsObjects;
    public GameObject[] Scenes;
    [SerializeField] private GameObject[] Managers;

    private InkDialogueManager _inkDialogueManager;
    private QuizUI _quizUI;
    
    [SerializeField] private IntVariable numberScene;

    
 
    private void Awake()
    {
        SetGameObjectsActive(true);
    }

    private void Update()
    {
        Activator();
    }

    void Activator()
    {
        int sceneIndex = numberScene.Value - 1;
        if (sceneIndex < 0 || sceneIndex >= Scenes.Length)
        {
            Debug.LogError("Invalid scene index");
            return;
        }

        GameObject sceneObject = Scenes[sceneIndex];
        sceneObject.SetActive(true);

        GameObject questionObject = questionsObjects[sceneIndex];
        GameObject managerObject = Managers[sceneIndex];

        if (InkDialogueManager.GetInstance().endStory)
        {
            questionObject.SetActive(true);
            managerObject.SetActive(true);
        }
    }
    private void SetGameObjectsActive(bool active)
    {
        for (int i = 0; i < questionsObjects.Length; i++)
        {
            questionsObjects[i].gameObject.SetActive(false);
            Scenes[i].gameObject.SetActive(false);
            Managers[i].gameObject.SetActive(false);
        }
    }
    
}
