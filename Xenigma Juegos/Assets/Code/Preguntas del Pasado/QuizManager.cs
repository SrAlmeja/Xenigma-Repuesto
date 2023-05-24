using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptable quizData;
    
    private List<Question> _questions;
    private Question selectedQuestion;

    private void Start()
    {
        _questions = quizData.questions;
        
        SelectedQuestion();
    }

    void SelectedQuestion()
    {
        int val = Random.Range(0, _questions.Count);
        selectedQuestion = _questions[val];

        quizUI.SetQuestion(selectedQuestion);
    }

    public bool Answer(string answered)
    {
        bool correctAns = false;
        if (answered == selectedQuestion.correctAns)
        {
            correctAns = true;
        }
        else
        {
            
        }
        
        Invoke("SelectedQuestion", 0.4f);

        return correctAns;
    }
}



[System.Serializable]
public class Question
{
    public string questionInfo;
    public QuestionType QuestionType;
    public Sprite questionImage;
    public AudioClip questionClip;
    public UnityEngine.Video.VideoClip questionVideo;
    public List<string> options;
    public string correctAns;
}

[System.Serializable]
public enum QuestionType
{
    TEXT,
    IMAGE,
    VIDEO,
    AUDIO
}
