using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class AddPoints : MonoBehaviourPun
{
    [SerializeField] private AnswerBtnScript _answerBtnScript;
    [SerializeField] private QuestionWindow _question;
    private NetworkPlayer _networkPlayer;
    public int points;
    [SerializeField] private int _playerID;

    public void AddPointsToPlayer()
    {
        _playerID = _answerBtnScript._playerID;

        Player targetPlayer = null;
        foreach (var player in PhotonNetwork.PlayerList)
        {
            if (player.GetPlayerNumber() == _playerID)
            {
                targetPlayer = player;
                break;
            }
        }
        
        foreach (var networkPlayer in FindObjectsOfType<NetworkPlayer>())
        {
            if (networkPlayer.photonView.Owner == targetPlayer)
            {
                _networkPlayer = networkPlayer;
                break;
            }
        }
        
        points = _question.points;
        _networkPlayer.points += points;
    }
    
    
}