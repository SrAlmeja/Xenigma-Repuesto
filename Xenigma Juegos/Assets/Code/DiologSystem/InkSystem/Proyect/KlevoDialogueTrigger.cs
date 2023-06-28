using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KlevoDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")] [SerializeField]
    private TextAsset inkJASON;

    [Header("Game Trigger")] [SerializeField]
    private GameObject[] questionsObjects;

    [SerializeField] private IntVariable NumberScene;

    private void Awake()
    {
        for (int i = 0; i < questionsObjects.Length; i++)
        {
            questionsObjects[i].gameObject.SetActive(false);
        }
    }

    void Start()
    {
        InkDialogueManager.GetInstance().EnterDialogueMode(inkJASON);
        
        
    }
}