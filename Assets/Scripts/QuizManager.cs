using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestionIndex;

    public UnityEngine.UI.Text QuestionText;

    private void Start()
    {
        generateQuestions();
    }
    public void correct()
    {
        generateQuestions();
        QnA.RemoveAt(currentQuestionIndex);
    }
    public void incorrect()
    {
        generateQuestions();
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;

            UnityEngine.UI.Text answerText = options[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
            answerText.text = QnA[currentQuestionIndex].answers[i];
            answerText.fontSize = 25;

            // Center the text horizontally and vertically
            answerText.alignment = TextAnchor.MiddleCenter;

            if (QnA[currentQuestionIndex].correctAnswerIndex == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestions()
    {
        currentQuestionIndex = Random.Range(0, QnA.Count);

        QuestionText.text = QnA[currentQuestionIndex].Question;
        SetAnswers();
    }
}
