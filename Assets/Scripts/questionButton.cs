using UnityEngine;
using TMPro;
using Photon.Pun;
public class questionButton : MonoBehaviourPun
{
    public int _pointsAmount;
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
    [PunRPC] public void NetworkLoadQuestion()
    {
        photonView.RPC("LoadQuestion", RpcTarget.All);
    }

    [PunRPC]
    public void LoadQuestion()
    {
        if (_questionSO == null)
        {
            Debug.LogError("No question assigned to button");
        }
        _question.sprite = _questionSO.Image;
        _question._withImage = _questionSO.withImage;
        _question.question = _questionSO.question;
        _question.points = _pointsAmount;
        if (_questionSO.answer != null)
        {
            _question.answer = _questionSO.answer;
        }
        else
        {
            _question.answer = "No answer";
        }
        _question.LoadQuestionWindow();
        gameObject.SetActive(false);
    }
}

