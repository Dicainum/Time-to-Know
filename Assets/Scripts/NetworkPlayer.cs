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
    private PlayerNumbering _playerNumbering;
    public int PlayerID;

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
        var players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                var netPlayer = players[i].GetComponent<NetworkPlayer>();
                netPlayer.photonView.RPC("InitilizePlayerID", RpcTarget.AllBuffered, i);
            }
        }
    }
}
