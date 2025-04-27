using UnityEngine;
using Photon.Pun;
using TMPro;
public class NetworkPlayer : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback 
{
    public int playerID  = 0;
    public string playerName = "";
    public Sprite playerImage;
    public int points = 0;
    public TMP_Text textPoints;

    public void UpdatePoints()
    {
        textPoints.text = points.ToString();
    }
    
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        photonView.RPC("PlacePlayers", RpcTarget.All);
    }
    
    [PunRPC] public void PlacePlayers()
    {
        Debug.Log("Players Placed");
        var players = GameObject.FindGameObjectsWithTag("Player");
        var host = GameObject.FindGameObjectWithTag("Host");
        var playerCanvas = GameObject.FindGameObjectWithTag("PlayerCanvas");
        var hostCanvas = GameObject.FindGameObjectWithTag("HostCanvas");
        if (players.Length > 0)
        {
            foreach (var player in players)
            {
                player.transform.SetParent(playerCanvas.transform, false);
            }
        }
        
        host.transform.SetParent(hostCanvas.transform, false);
    }
}
