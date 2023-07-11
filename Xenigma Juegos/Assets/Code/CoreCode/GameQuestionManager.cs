using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameQuestionManager : MonoBehaviour
{
    [Header("Game Trigger")] 
    [SerializeField]
    private GameObject[] questionsObjects;
    public GameObject[] Scenes;
    [SerializeField] private GameObject[] Managers;

    private InkDialogueManager _inkDialogueManager;
    private QuizUI _quizUI;

    

    private void Awake()
    {
        for (int i = 0; i < questionsObjects.Length; i++)
        {
            questionsObjects[i].gameObject.SetActive(false);
            Scenes[i].gameObject.SetActive(false);
            Managers[i].gameObject.SetActive(false);
        }
    }
    
    [SerializeField] private IntVariable numberScene;
    // Start is called before the first frame update

    private void Update()
    {
        Activator();
    }

    void Activator()
    {
        switch (numberScene.Value)
        {
            case 1:
                Scenes[0].gameObject.SetActive(true);

                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[0].gameObject.SetActive(true);
                    Managers[0].gameObject.SetActive(true);
                }
                
                
                if (_quizUI.istheGameOver)
                {
                    Debug.Log("Se deberia apagar todo" + _quizUI.istheGameOver);
                    questionsObjects[0].gameObject.SetActive(false);
                    Managers[0].gameObject.SetActive(false);
                }

                break;
            case 2:
                
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[1].gameObject.SetActive(true);
                    Managers[1].gameObject.SetActive(true);
                }
                
                if (_quizUI.istheGameOver = true)
                {
                    questionsObjects[1].gameObject.SetActive(false);
                    Managers[1].gameObject.SetActive(false);
                }

                Scenes[1].gameObject.SetActive(true);
                
                break; 
            case 3:
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[2].gameObject.SetActive(true);
                    Managers[2].gameObject.SetActive(true);
                }
                
                if (_quizUI.istheGameOver = true)
                {
                    questionsObjects[2].gameObject.SetActive(false);
                    Managers[2].gameObject.SetActive(false);
                }

                Scenes[2].gameObject.SetActive(true);
                
                break; 
            case 4:
                
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[3].gameObject.SetActive(true);
                    Managers[3].gameObject.SetActive(true);
                }

                if (_quizUI.istheGameOver = true)
                {
                    questionsObjects[3].gameObject.SetActive(false);
                    Managers[3].gameObject.SetActive(false);
                }
                
                Scenes[3].gameObject.SetActive(true);
               
                break; 
            case 5:
                
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[4].gameObject.SetActive(true);
                    Managers[4].gameObject.SetActive(true);
                }
                
                if (_quizUI.istheGameOver = true)
                {
                    questionsObjects[4].gameObject.SetActive(false);
                    Managers[4].gameObject.SetActive(false);
                }
               
                Scenes[4].gameObject.SetActive(true);
                
                break; 
            case 6:
                
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[5].gameObject.SetActive(true);
                    Managers[5].gameObject.SetActive(true);
                }

                if (_quizUI.istheGameOver = true)
                {
                    questionsObjects[5].gameObject.SetActive(false);
                    Managers[5].gameObject.SetActive(false);
                }
                
                Scenes[5].gameObject.SetActive(true);
                
                break; 
            case 7:
                
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[6].gameObject.SetActive(true);
                    Managers[6].gameObject.SetActive(true);
                }

                if (_quizUI.istheGameOver = true)
                {
                    questionsObjects[6].gameObject.SetActive(false);
                    Managers[6].gameObject.SetActive(false);
                }
                
                Scenes[6].gameObject.SetActive(true);
                
                break; 
            case 8:
                
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[7].gameObject.SetActive(true);
                    Managers[7].gameObject.SetActive(true);
                }

                if (_quizUI.istheGameOver = true)
                {
                    questionsObjects[7].gameObject.SetActive(false);
                    Managers[7].gameObject.SetActive(false);
                }
                
                Scenes[7].gameObject.SetActive(true);
                
                break; 
            case 9:
                
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[8].gameObject.SetActive(true);
                    Managers[8].gameObject.SetActive(true);
                }
                
                if (_quizUI.istheGameOver = true)
                {
                    questionsObjects[8].gameObject.SetActive(false);
                    Managers[8].gameObject.SetActive(false);
                }

                Scenes[8].gameObject.SetActive(true);
                
                break; 
        }
    }
}
