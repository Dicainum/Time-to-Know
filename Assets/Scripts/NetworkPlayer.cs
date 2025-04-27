using System;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;
public class NetworkPlayer : MonoBehaviourPunCallbacks//, IPunInstantiateMagicCallback 
{
    public string playerName = "";
    public Sprite playerImage;
    public int points = 0;
    public TMP_Text textPoints;
    private PlayerNumbering _playerNumbering;

    public void UpdatePoints()
    {
        textPoints.text = points.ToString();
    }

    // private void Start()
    // {
    //    // photonView.RPC("PlacePlayers", RpcTarget.All);
    // }
    //
    // // public void OnPhotonInstantiate(PhotonMessageInfo info)
    // // {
    // //     photonView.RPC("PlacePlayers", RpcTarget.All);
    // // }
    //
    // [PunRPC] public void PlacePlayers()
    // {
    //     Debug.Log("Players Placed");
    //     var players = GameObject.FindGameObjectsWithTag("Player");
    //     //var host = GameObject.FindGameObjectWithTag("Host");
    //     var playerCanvas = GameObject.FindGameObjectWithTag("PlayerCanvas");
    //     //var hostCanvas = GameObject.FindGameObjectWithTag("HostCanvas");
    //     if (players.Length > 0)
    //     {
    //         foreach (var player in players)
    //         {
    //             player.transform.SetParent(playerCanvas.transform, false);
    //         }
    //     }

       /// if (host != null && host.transform.parent != hostCanvas.transform)
       /// {
           // host.transform.SetParent(hostCanvas.transform, false);
        //}
   // }
}
