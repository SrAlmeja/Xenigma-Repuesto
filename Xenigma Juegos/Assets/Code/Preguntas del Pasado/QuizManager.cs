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

    public IntVariable Chances; 
    
    private void Start()
    {
        _questions = quizData.questions;
        
        SelectedQuestion();

        Chances.Value = 3;
    }

    void SelectedQuestion() //Seleccionador random de las preguntas
    {
        int val = Random.Range(0, _questions.Count);
        selectedQuestion = _questions[val];

        quizUI.SetQuestion(selectedQuestion);
        
        _questions.RemoveAt(val);
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
            correctAns = false;
            Chances.Value--;
            Debug.Log("Te quedan solo " + Chances.Value + " oportunidades");
        }
        
        Invoke("SelectedQuestion", 0.4f);

        return correctAns;
    }
}



[System.Serializable]
public class Question  // Aqui va toda la informacion que un objeto Question debe tener
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
public enum QuestionType  //El tipo de objeto question debe ser
{
    TEXT,
    IMAGE,
    VIDEO,
    AUDIO
}
