using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LobbyNetworkSettings : MonoBehaviourPun
{
    [SerializeField] private GameObject _playerCanvas;
    [SerializeField] private GameObject _hostCanvas;
    // private void Start()
    // {
    //      Debug.Log("Players Placed");
    //      var players = GameObject.FindGameObjectsWithTag("Player");
    //      var host = GameObject.FindGameObjectWithTag("Host");
    //      
    //      if(players.Length != 0)
    //      {
    //          foreach (var player in players)
    //          {
    //              player.transform.SetParent(_playerCanvas.transform, false);
    //          }
    //      }
    //      host.transform.SetParent(_hostCanvas.transform, false);
    // }

    public void RestartGame()
    {
        if (!PhotonNetwork.IsMasterClient) return;
        PhotonNetwork.DestroyAll();
        PhotonNetwork.LoadLevel("RestartScene");
    }
}