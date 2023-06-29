using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuestionManager : MonoBehaviour
{
    [Header("Game Trigger")] 
    [SerializeField]
    private GameObject[] questionsObjects;
    [SerializeField] private GameObject[] Scenes;
    [SerializeField] private GameObject[] Managers;

    private InkDialogueManager _inkDialogueManager;

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
                Debug.Log("Abrir Nivel 1");
                Scenes[0].gameObject.SetActive(true);
                
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[0].gameObject.SetActive(true);
                    Managers[0].gameObject.SetActive(true);
                }
                
                
                break;
            case 2:
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[1].gameObject.SetActive(true);
                    Managers[1].gameObject.SetActive(true);
                }
                Debug.Log("Abrir Nivel 2");
                
                Scenes[1].gameObject.SetActive(true);
                
                break; 
            case 3:
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[2].gameObject.SetActive(true);
                    Managers[2].gameObject.SetActive(true);
                }
                Debug.Log("Abrir Nivel 3");
                
                Scenes[2].gameObject.SetActive(true);
                
                break; 
            case 4:
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[3].gameObject.SetActive(true);
                    Managers[3].gameObject.SetActive(true);
                }
                Debug.Log("Abrir Nivel 4");
                
                Scenes[3].gameObject.SetActive(true);
               
                break; 
            case 5:
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[4].gameObject.SetActive(true);
                    Managers[4].gameObject.SetActive(true);
                }
                Debug.Log("Abrir Nivel 5");
                Scenes[4].gameObject.SetActive(true);
                
                break; 
            case 6:
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[5].gameObject.SetActive(true);
                    Managers[5].gameObject.SetActive(true);
                }
                Debug.Log("Abrir Nivel 6");
                
                Scenes[5].gameObject.SetActive(true);
                
                break; 
            case 7:
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[6].gameObject.SetActive(true);
                    Managers[6].gameObject.SetActive(true);
                }
                Debug.Log("Abrir Nivel 7");
                
                Scenes[6].gameObject.SetActive(true);
                
                break; 
            case 8:
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[7].gameObject.SetActive(true);
                    Managers[7].gameObject.SetActive(true);
                }
                Debug.Log("Abrir Nivel 8");
                
                Scenes[7].gameObject.SetActive(true);
                
                break; 
            case 9:
                if (InkDialogueManager.GetInstance().endStory)
                {
                    questionsObjects[8].gameObject.SetActive(true);
                    Managers[8].gameObject.SetActive(true);
                }
                Debug.Log("Abrir Nivel 9");
                
                Scenes[8].gameObject.SetActive(true);
                
                break; 
        }
    }
}
