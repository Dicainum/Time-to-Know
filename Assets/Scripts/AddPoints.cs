using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class AddPoints : MonoBehaviourPun
{
    [SerializeField] private AnswerBtnScript _answerBtnScript;
    public int points;
    private int _playerID;

    public void AddPointsToPlayer(int addedPoints)
    {
        points += addedPoints; // Увеличиваем очки
        _playerID = PhotonNetwork.LocalPlayer.ActorNumber; // Сохраняем ID игрока
        Debug.Log($"Добавлено {addedPoints} очков игроку с ID {_playerID}");
    }
}