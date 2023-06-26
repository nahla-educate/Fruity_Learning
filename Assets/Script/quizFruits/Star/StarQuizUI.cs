using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarQuizUI : MonoBehaviour
{
    [SerializeField] private AudioSource wrongAnsSound;
    [SerializeField] private AudioSource correctAnsSound;
    [SerializeField] private StarQuizManager quizManager;
    [SerializeField] private Text questionText, scoreText, bestscoreText;
    [SerializeField] private Image questionImage;
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color wrongCol, normalCol, correctCol;

    private QuestionStar question;
    private bool answered;
    private float audioLength;

    public Text ScoreText { get { return scoreText; } }
    public Text BestScoreText { get { return bestscoreText; } }

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    public void SetQuestion(QuestionStar question)
    {
        this.question = question;
        switch (question.questionType)
        {
            case QuestionStarType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionStarType.IMAGE:
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = question.questionImg;
                break;
            case QuestionStarType.VIDEO:
                ImageHolder();
                questionVideo.transform.gameObject.SetActive(true);
                questionVideo.clip = question.questionVideo;
                questionVideo.Play();
                break;
            case QuestionStarType.AUDIO:
                ImageHolder();
                questionAudio.transform.gameObject.SetActive(true);
                audioLength = question.questionClip.length;
                StartCoroutine(PlayAudio());
                break;
        }
        questionText.text = question.questionInfo;
        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalCol;
        }
        answered = false;
    }
    IEnumerator PlayAudio()
    {
        if (question.questionType == QuestionStarType.AUDIO)
        {
            questionAudio.PlayOneShot(question.questionClip);

            yield return new WaitForSeconds(audioLength + 0.5f);
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

        if (!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if (val)
            {
                correctAnsSound.Play();
                btn.image.color = correctCol;



            }
            else
            {
                wrongAnsSound.Play();
                btn.image.color = wrongCol;
            }
        }
    }
}
