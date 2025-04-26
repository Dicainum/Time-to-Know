using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class AnswerBtnScript : MonoBehaviour
{
    [SerializeField] private TimerScript _resetScript;
    private bool ifResetBeenCalled = false;
    [SerializeField] private Button _answerBtn;
    [SerializeField] private TMP_Text _playerAnswerText;
    [SerializeField] private GameObject _questionWindow;

    private void Awake()
    {
        GameObject _answerObj = GameObject.FindGameObjectWithTag("AnswerButton");

        if (_answerObj != null)
        {
            _answerBtn = _answerObj.GetComponent<Button>();
        }
    }

    public void AnswerBtnClicked()
    {
        if (!ifResetBeenCalled && _questionWindow.activeSelf)
        {
            _resetScript.ResetTimer();
            ifResetBeenCalled = true;
            PlayerAnswering();
        }
    }

    public void ResetAnswerButton()
    {
        _answerBtn.interactable = true;
        _playerAnswerText.text = "Answer";
    }

    private void PlayerAnswering()
    {
        _playerAnswerText.text = "Answering..."; //playerName + 
    }
}
