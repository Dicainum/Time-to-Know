using System;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;
public class NetworkPlayer : MonoBehaviourPunCallbacks
{
    public string playerName = "";
    public Sprite playerImage;
    public int points = 0;
    public TMP_Text textPoints;
    public TMP_Text nicknameText;
    private PlayerNumbering _playerNumbering;
    public int PlayerID;
    private GameObject[] _players;

    public void UpdatePoints()
    {
        textPoints.text = points.ToString();
    }

    [PunRPC]
    public void InitilizePlayerID(int ID)
    {
        PlayerID = ID;
    }

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _players = GameObject.FindGameObjectsWithTag("Player");
            if (_players.Length > 0)
            {
                for (int i = 0; i < _players.Length; i++)
                {
                    var netPlayer = _players[i].GetComponent<NetworkPlayer>();
                    if (netPlayer != null && netPlayer.photonView != null)
                    {
                        netPlayer.photonView.RPC("InitilizePlayerID", RpcTarget.AllBuffered, i);
                    }
                }
            }
        }
    }

    [PunRPC]
    public void SynchNicknames()
    {
        photonView.RPC("SetNicknames", RpcTarget.AllBuffered);
    }
    [PunRPC] private void SetNicknames()
    {
        _players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in _players)
        {
            var netPlayer = player.GetComponent<NetworkPlayer>();
            var nickname = player.GetComponent<PhotonView>().Owner.NickName;
            netPlayer.playerName = nickname;
            netPlayer.nicknameText.text = nickname;
        }
        
        var host = GameObject.FindGameObjectsWithTag("Host");
        
        foreach (var player in host)
        {
            var netPlayer = player.GetComponent<NetworkPlayer>();
            var nickname = player.GetComponent<PhotonView>().Owner.NickName;
            netPlayer.playerName = nickname;
            netPlayer.nicknameText.text = nickname;
        }
    }
}
