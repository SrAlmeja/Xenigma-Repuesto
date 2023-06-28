using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuestionManager : MonoBehaviour
{
    [Header("Game Trigger")] [SerializeField]
    private GameObject[] questionsObjects;

    private InkDialogueManager _inkDialogueManager;

    private void Awake()
    {
        for (int i = 0; i < questionsObjects.Length; i++)
        {
            questionsObjects[i].gameObject.SetActive(false);
        }
    }
    
    [SerializeField] private IntVariable numberScene;
    // Start is called before the first frame update

    private void Update()
    {
        switch (numberScene.Value)
        {
            case 1:
                Debug.Log("Abrir Nivel 1");
                break;
            case 2:
                Debug.Log("Abrir Nivel 2");
                break; 
            case 3:
                Debug.Log("Abrir Nivel 3");
                break; 
            case 4:
                Debug.Log("Abrir Nivel 4");
                break; 
            case 5:
                Debug.Log("Abrir Nivel 5");
                break; 
            case 6:
                Debug.Log("Abrir Nivel 6");
                break; 
            case 7:
                Debug.Log("Abrir Nivel 7");
                break; 
            case 8:
                Debug.Log("Abrir Nivel 8");
                break; 
            case 9:
                Debug.Log("Abrir Nivel 9");
                break; 
        }
    }
}
