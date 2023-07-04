using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinematicDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")] [SerializeField]
    private TextAsset inkJASON;

    [Header("Intro Animator Controller")] [SerializeField]
    private Animator intro;
    
    void Start()
    {
        intro.Play("StartCinematic");
    }

    public void EndAnimation()
    {
        intro.Play("EndIntro");
    }
    public void InizialiceDialogue()
    {
        InkDialogueManager.GetInstance().EnterDialogueMode(inkJASON);
    }
}
