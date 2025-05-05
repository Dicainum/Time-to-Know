using System.Linq;
using TMPro;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    [SerializeField] private AnswerBtnScript answerBtnScript;
    [SerializeField] private TMP_Text debugText;
    private NetworkPlayer[] _players;

    private void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        _players = playerObjects
            .Select(go => go.GetComponent<NetworkPlayer>())
            .Where(np => np != null)
            .ToArray();    
    }

    private void LateUpdate()
    {
        foreach (var player in _players)
        {
            if (player.PlayerID == answerBtnScript._playerID)
            {
                debugText.text = player.playerName;
            }
        }
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        _players = playerObjects
            .Select(go => go.GetComponent<NetworkPlayer>())
            .Where(np => np != null)
            .ToArray();    }
}
