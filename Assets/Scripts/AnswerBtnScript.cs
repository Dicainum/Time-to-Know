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
        ifResetBeenCalled = false;
        _playerAnswerText.text = "Answer";
    }

    private void PlayerAnswering()
    {
        _answerBtn.interactable = false;
        _playerAnswerText.text = "Answering..."; //playerName + 
    }
}
