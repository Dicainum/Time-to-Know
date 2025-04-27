using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;


public class AnswerBtnScript : MonoBehaviourPun
{
    [SerializeField] private TimerScript _resetScript;
    private bool ifResetBeenCalled = false;
    [SerializeField] private Button _answerBtn;
    [SerializeField] private TMP_Text _playerAnswerText;
    [SerializeField] private GameObject _questionWindow;
    public int _playerID;
    public void AnswerBtnClicked()
    {
        if (!ifResetBeenCalled && _questionWindow.activeSelf)
        {
            _resetScript.ResetTimer();
            ifResetBeenCalled = true;
            PlayerAnswering();
            _playerID = PhotonNetwork.LocalPlayer.ActorNumber;
            Debug.Log($"Player ID: {_playerID}");
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
        _playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        _answerBtn.interactable = false;
        _playerAnswerText.text = "Answering..."; //playerName + 
    }
}
