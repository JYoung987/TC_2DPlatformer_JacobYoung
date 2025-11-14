using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizmanager;
    public CollectableManager cm;
    public GameObject quizUI;
    public HealthManager hm;
    public void Answer()
    {
        if (isCorrect)
        {
            hm.Heal(100);
            cm.CollectableCount += 1;
            Debug.Log("correct answer");
            quizmanager.correct();
            quizUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.Log("Incorrect answer");
            quizmanager.incorrect();
        }
    }
}
