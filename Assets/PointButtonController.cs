using UnityEngine;
using Photon.Pun;

public class PointButtonController : MonoBehaviourPun
{
    [SerializeField] private GameObject[] _pointsButtons;
    public void SetButtonsInactive()
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        foreach (var button in _pointsButtons)
        {
            button.SetActive(false);
        }
    }

    public void SetButtonsActive()
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        foreach (var button in _pointsButtons)
        {
            button.SetActive(true);
        }
    }
}
