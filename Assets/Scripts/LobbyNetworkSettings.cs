using System;
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
    private NetworkPlayer _host;
    [SerializeField] private PlayerSort _playerSort;
    private List<Player> playersList;
    private List<NetworkPlayer> networkPlayers;

    [SerializeField] private GameObject _restartBtn;
    [SerializeField] private GameObject[] _hostGameObjects;

    private void Awake()
    {
        playersList = PhotonNetwork.PlayerList.ToList();
        networkPlayers = new List<NetworkPlayer>();
        for (var i = 0; i < playersList.Count; i++)
        {
            if (playersList[i].ActorNumber != PhotonNetwork.LocalPlayer.ActorNumber) continue;

            GameObject prefabToSpawn = PhotonNetwork.IsMasterClient ? hostPrefab : playerPrefab;
            var go = PhotonNetwork.Instantiate(prefabToSpawn.name, Vector3.zero, Quaternion.identity);
            if (go.GetComponent<MyPlayerReference>() == null)
            {
                go.AddComponent<MyPlayerReference>();
            }
            networkPlayers.Add(go.GetComponent<NetworkPlayer>());
            break;
        }
    }

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _host = GameObject.FindGameObjectWithTag("Host").GetComponent<NetworkPlayer>();
        }       
        else
        {
            foreach (var go in _hostGameObjects)
            {
                go.SetActive(false);
            }
        }
    }

    [PunRPC]
    public void SortButton()
    {
        _host.SynchNicknames();
        photonView.RPC("Sort", RpcTarget.AllBufferedViaServer);
    }
    [PunRPC] private void Sort()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.transform.SetParent(playerCanvas.transform, false);
        }
        var host = GameObject.FindGameObjectWithTag("Host");
        if (host == null)
        {
            Debug.LogError("Host not found");
        }
        else
        {
            host.transform.SetParent(hostCanvas.transform, false);
        }

        _playerSort.SortChildrenByPlayerId();
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