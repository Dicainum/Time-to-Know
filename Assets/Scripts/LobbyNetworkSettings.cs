using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LobbyNetworkSettings : MonoBehaviourPun
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject hostPrefab;


    [SerializeField] private GameObject playerCanvas;
    [SerializeField] private GameObject hostCanvas;
    private List<Player> playersList;
    private List<NetworkPlayer> networkPlayers;

    [SerializeField] private GameObject _restartBtn;
    
    private void Awake()
    {
        playersList = PhotonNetwork.PlayerList.ToList();
        networkPlayers = new List<NetworkPlayer>();
        for (var i = 0; i < playersList.Count; i++)
        {
            if (playersList[i].ActorNumber != PhotonNetwork.LocalPlayer.ActorNumber) continue;

            
            GameObject prefabToSpawn = PhotonNetwork.IsMasterClient ? hostPrefab : playerPrefab;
            GameObject canvasToAttach = PhotonNetwork.IsMasterClient ? hostCanvas : playerCanvas;

            var go = PhotonNetwork.Instantiate(prefabToSpawn.name, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(canvasToAttach.transform, false);

            networkPlayers.Add(go.GetComponent<NetworkPlayer>());
            break;
        }
    }


    // public void KillPlayer(PhotonView playerView)
    // {
    //     for (var i = 0; i < playersList.Count; i++)
    //     {
    //         if (playersList[i].ActorNumber != playerView.Controller.ActorNumber) continue;
    //         playersControllers[i].KillPlayer();
    //         break;
    //     }
    // }

    public void RestartGame()
    {
        if (!PhotonNetwork.IsMasterClient) return;
        PhotonNetwork.DestroyAll();
        PhotonNetwork.LoadLevel("RestartScene");
    }
}