using Photon.Pun;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float remainingTime;
    [SerializeField] private RandomBtnScript _randomScript;
    [SerializeField] private AnswerBtnScript _answerButtonScript;
    private bool timerEnded = false;
    [SerializeField] private GameObject _questionWindow;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("PauseTimer", RpcTarget.All);
        }
    }

    private void FixedUpdate()
    {
        if (timerEnded) return;

        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        
        if (seconds > 0)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = "00:00";
            TimerEnd();
        }
    }

    [PunRPC]
    public void ResetTimer()
    {
        Debug.LogWarning("ResetTimer");
        remainingTime = 11f;
        timerEnded = false;
    }

    [PunRPC]
    public void PauseTimer()
    {
        timerEnded = true;
    }

    [PunRPC]
    public void HostResumeTimer()
    {
        photonView.RPC("ResumeTimer", RpcTarget.AllViaServer);
    }

    [PunRPC] public void ResumeTimer()
    {
        timerEnded = false;
    }
    

    private void TimerEnd()
    {
        if (_randomScript != null && remainingTime <= -0.5f && !timerEnded)
        {
            timerEnded = true;
            ResetInAnswer();
        }
    }

    [PunRPC]
    public void CallResetInAnser()
    {
        photonView.RPC("ResetInAnswer", RpcTarget.AllViaServer);

    }

    [PunRPC] 
    public void ResetInAnswer()
    {
        if (!_questionWindow.activeSelf)
        {
            _randomScript.SelectRandomButton();
        }
        else
        {
            _questionWindow.SetActive(false);
            ResetTimer();
            _answerButtonScript.ResetAnswerButton();
        }
    }
}