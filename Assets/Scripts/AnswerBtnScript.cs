using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.UtilityScripts;


public class AnswerBtnScript : MonoBehaviourPun
{
    [SerializeField] private TimerScript _resetScript;
    private bool ifResetBeenCalled = false;
    [SerializeField] private Button _answerBtn;
    [SerializeField] private TMP_Text _playerAnswerText;
    [SerializeField] private GameObject _questionWindow;
    public int _playerID;
    [PunRPC]
    public void AnswerBtnClicked()
    {
        if (!ifResetBeenCalled && _questionWindow.activeSelf)
        {
            _resetScript.ResetTimer();
            ifResetBeenCalled = true;

            PlayerAnswering();

            var localPlayerObject = PhotonView.Find(PhotonNetwork.LocalPlayer.ActorNumber);
            Debug.LogError(localPlayerObject);
            if (localPlayerObject != null)
            {
                var netPlayer = localPlayerObject.gameObject.GetComponent<NetworkPlayer>();
                Debug.Log(netPlayer.gameObject.name);//TODO: Got NRE here
                int playerID = netPlayer.PlayerID;

                photonView.RPC("BroadcastPlayerClicked", RpcTarget.AllBufferedViaServer, playerID);
            }
        }
    }

    [PunRPC] public void BroadcastPlayerClicked(int playerID)
    {
        _playerID = playerID;
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
