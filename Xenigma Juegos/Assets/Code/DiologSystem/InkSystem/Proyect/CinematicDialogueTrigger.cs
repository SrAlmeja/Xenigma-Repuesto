using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinematicDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")] [SerializeField]
    private TextAsset inkJASON;
    
   
    void Start()
    {
        InkDialogueManager.GetInstance().EnterDialogueMode(inkJASON);
    }
}
