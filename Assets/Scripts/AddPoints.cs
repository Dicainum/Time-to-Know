using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using Unity.VisualScripting;

public class AddPoints : MonoBehaviourPun
{
    [SerializeField] private AnswerBtnScript _answerBtnScript;
    [SerializeField] private QuestionWindow _question;
    public int points;
    [SerializeField] private int _playerID;
    private NetworkPlayer[] _players;

    

    
    public void AddPointsToPlayer()
    {
        _playerID = _answerBtnScript._playerID;

        NetworkPlayer targetPlayer = null;
        if (_players == null || _players.Length == 0)
        {
            var playersGO = GameObject.FindGameObjectsWithTag("Player");
            _players = new NetworkPlayer[playersGO.Length];

            for (int i = 0; i < playersGO.Length; i++)
            {
                _players[i] = playersGO[i].GetComponent<NetworkPlayer>();
            }
        }
        
        foreach (var player in _players)
        {
            if (player.PlayerID == _playerID)
            {
                targetPlayer = player;
                break;
            }
        }

        if (targetPlayer = null)
        {
            Debug.LogWarning("Player " + _playerID + " not found");
        }
        else
        {
            points = _question.points;
            targetPlayer.points += points; 
        }
    }
    
    
}