using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class NetworkPlayer : MonoBehaviourPunCallbacks
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
}
