using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class KlevoDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")] [SerializeField]
    private TextAsset inkJASON;

    void Start()
    {
        InkDialogueManager.GetInstance().EnterDialogueMode(inkJASON);
    }
    
}