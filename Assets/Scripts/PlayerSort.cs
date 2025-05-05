using System.Linq;
using UnityEngine;

public class PlayerSort : MonoBehaviour
{
    public void SortChildrenByPlayerId()
    {
        var players = GetComponentsInChildren<NetworkPlayer>()
            .OrderBy(p => p.PlayerID)
            .ToArray();

        for (int i = 0; i < players.Length; i++)
        {
            players[i].transform.SetSiblingIndex(i);
        }
    }
}
