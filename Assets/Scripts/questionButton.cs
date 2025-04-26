using UnityEngine;
using TMPro;

public class questionButton : MonoBehaviour
{
    private int _pointsAmount;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private QuestionSO _questionSO;
    private GameObject _questionWindow;
    private QuestionWindow _question;


    private void Awake()
    {
        _pointsAmount = _questionSO.points;
        _text.text = _pointsAmount.ToString();
        _questionWindow = GameObject.FindGameObjectWithTag("QuestionWindow");
        Debug.Log(_questionWindow.name);
        _question = _questionWindow.GetComponent<QuestionWindow>();
    }
    public void LoadQuestion()
    {
        if (_questionSO == null)
        {
            Debug.LogError("No question assigned to button");
        }
        _question.sprite = _questionSO.Image;
        _question._withImage = _questionSO.withImage;
        _question.question = _questionSO.question;
        _question.LoadQuestionWindow();
        gameObject.SetActive(false);

    }
}

