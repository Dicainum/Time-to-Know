using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using Unity.VisualScripting;

public class AddPoints : MonoBehaviourPun
{
    [SerializeField] private AnswerBtnScript _answerBtnScript;
    [SerializeField] private QuestionWindow _question;
    public int points;
    [SerializeField] private int _playerID;
    [SerializeField] private int _multiplier = 1;
    [SerializeField] private PointButtonController _buttonController;
    [SerializeField] private TimerScript _timerScript;
    [SerializeField] private LobbyNetworkSettings _lobbyNetworkSettings;
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

        if (targetPlayer == null)
        {
            Debug.LogWarning("Player " + _playerID + " not found");
        }
        else
        {
            points = _question.points * _multiplier;
            targetPlayer.points += points;
            SyncAllPlayersPoints();
        }

        _timerScript.CallResetInAnser();
        _buttonController.SetButtonsInactive();
    }

    private void SyncAllPlayersPoints()
    {
        var allPoints = new int[_players.Length];

        for (int i = 0; i < _players.Length; i++)
        {
            allPoints[i] = _players[i].points;
        }

        _lobbyNetworkSettings.CallSynchPoints(allPoints);
    }

    [PunRPC]
    private void SynchPoints(int[] allPoints)
    {
        if (_players == null || _players.Length == 0)
        {
            var playersGO = GameObject.FindGameObjectsWithTag("Player");
            _players = new NetworkPlayer[playersGO.Length];
            for (int i = 0; i < playersGO.Length; i++)
            {
                _players[i] = playersGO[i].GetComponent<NetworkPlayer>();
            }
        }

        for (int i = 0; i < _players.Length; i++)
        {
            _players[i].points = allPoints[i];
            _players[i].UpdatePoints();
        }
        Debug.Log("Synched");
    }
    
    
}