using System.Linq;
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
    [SerializeField] private PointButtonController _addPoints;

    public int _playerID = 0;
    private NetworkPlayer[] _players;
    private string name;

    private void Start()
    {
        ResetAnswerButton();
    }

    public void OnAnswerButtonClicked()
    {
        if (_questionWindow.activeSelf)
        {
            var localPlayerObject = PhotonView.Find(PhotonNetwork.LocalPlayer.ActorNumber);
            if (localPlayerObject != null)
            {
                var netPlayer = MyPlayerReference.myNetworkPlayer;
                int playerID = netPlayer.PlayerID;
                photonView.RPC("SendClickToMaster", RpcTarget.MasterClient, playerID);
            }
        }
    }
    
    [PunRPC]
    public void SendClickToMaster(int playerID, PhotonMessageInfo info)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        if (!ifResetBeenCalled)
        {
            ifResetBeenCalled = true;
            _playerID = playerID;

            photonView.RPC("BroadcastPlayerClicked", RpcTarget.AllBufferedViaServer, playerID);

            _addPoints.SetButtonsActive();
        }
    }
    
    [PunRPC]
    public void BroadcastPlayerClicked(int playerID)
    {
        _playerID = playerID;
        FindNickname();
        PlayerAnswering();
    }
    
    public void ResetAnswerButton()
    {
        _answerBtn.interactable = true;
        ifResetBeenCalled = false;
        _playerAnswerText.text = "Answer"; 
    }


    private void FindNickname()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        _players = playerObjects
            .Select(go => go.GetComponent<NetworkPlayer>())
            .Where(np => np != null)
            .ToArray();

        foreach (var player in _players)
        {
            if (player.PlayerID == _playerID)
            {
                name = player.playerName;
                break;
            }
        }
    }
    
    private void PlayerAnswering()
    {
        _answerBtn.interactable = false;
        _playerAnswerText.text = name + " is Answering...";
    }
}
