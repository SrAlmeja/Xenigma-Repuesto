using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DiologManager : MonoBehaviour
{
    public Image ActorImage;
    public TextMeshProUGUI ActorName;
    public TextMeshProUGUI MessageText;
    public RectTransform backgroundBox;

    private Message[] currentMessage;
    private Actor[] currentActors;
    private int activeMessage = 0;
    public static bool isActive = false;
    
    public AudioSource diologueSound;

    public void OpenDiologue(Message[] messages, Actor[] actors)
    {
        currentMessage = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessage[activeMessage];
        MessageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        ActorName.text = actorToDisplay.name;
        ActorImage.sprite = actorToDisplay.sprite;
        backgroundBox.LeanScale(Vector3.one, 0.3f);
        
        AnimatedTextColor();
        diologueSound.Play();
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessage.Length)
        {
            DisplayMessage();
        }
        else
        {
            backgroundBox.LeanScale(Vector3.zero, 0.3f).setEaseInOutExpo();
            isActive = false;
        }
        
    }

    void AnimatedTextColor()
    {
        LeanTween.textAlpha(MessageText.rectTransform, 0, 0.0f);
        LeanTween.textAlpha(MessageText.rectTransform, 1, 0.6f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }

}
