using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;


public class QuizUI : MonoBehaviour
{
    [Header("Elementos del objeto Question")]
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;
    [SerializeField] private AudioSource questionAudio;
    [Header("Respuestas")]
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctColor, wrongColor, normalColor;

    private Question _question;
    private bool _answered;
    private float _audioLenght;

    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreManager _scoreManager;
    [SerializeField] private int points;
    [SerializeField] private IntVariable score;

    [Header("Win/Lose Conditions")]
    [SerializeField] private IntVariable chances;
    [SerializeField] private Animator heartA1, heartA2, heartA3;
    [SerializeField] private Animator loseWinCondition;
    [SerializeField] private GameObject lose, win;
    [HideInInspector] public bool istheGameOver;

    private void Awake()
    {
        istheGameOver = false;
        _scoreManager = new ScoreManager();
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    public void SetQuestion(Question question)
    {
        this._question = question;

        switch (question.QuestionType)
        {
            case QuestionType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                
                break;
            case QuestionType.IMAGE:
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);

                questionImage.sprite = question.questionImage;
                break;
            case QuestionType.VIDEO:
                ImageHolder();
                questionVideo.transform.gameObject.SetActive(true);

                questionVideo.clip = question.questionVideo;
                questionVideo.Play();
                break;
            case QuestionType.AUDIO:
                ImageHolder();
                questionAudio.transform.gameObject.SetActive(true);

                _audioLenght = _question.questionClip.length;

                StartCoroutine(PlayAudio());
                
                break;
        }

        questionText.text = question.questionInfo;

        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalColor;
        }

        _answered = false;
    }

    IEnumerator PlayAudio()
    {
        if (_question.QuestionType == QuestionType.AUDIO)
        {
            questionAudio.PlayOneShot(_question.questionClip);

            yield return new WaitForSeconds(_audioLenght + 0.5f);

            StartCoroutine(PlayAudio());
        }
        else
        {
            StopCoroutine(PlayAudio());
            yield return null;
        }
    }

    void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
        questionAudio.transform.gameObject.SetActive(false);
        questionVideo.transform.gameObject.SetActive(false);
    }

    private void OnClick(Button btn)
    {
        if (!_answered)
        {
            _answered = true;
            bool val = quizManager.Answer(btn.name);
            if (val)
            {
                btn.image.color = correctColor;
                score.Value += points;
            }
            else
            {
                btn.image.color = wrongColor;
                score.Value -= (points-20);
                LifeController();
            }
            scoreText.text = score.Value.ToString();
        }
    }

    public void LifeController()
    {
        if (chances.Value == 2)
        {
            heartA3.Play("HeartBroken");
        }

        if (chances.Value == 1)
        {
            heartA2.Play("HeartBroken");
            heartA1.Play("LastLife");
        }

        if (chances.Value <= 0)
        {
            heartA1.Play("HeartBroken");
            loseWinCondition.Play("LoseDiologue");
            lose.SetActive(true);
            istheGameOver = true;
        }
    }
    
    

}
