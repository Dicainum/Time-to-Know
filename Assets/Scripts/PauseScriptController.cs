using System.Linq;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseScriptController : MonoBehaviourPun
{
    [SerializeField] private GameObject unpauseButton;
    [SerializeField] private string hostText;
    [SerializeField] private string playerText;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private Button pauseButton;
    [SerializeField] private TimerScript timer;
    //[SerializeField] private GameObject  _nicknameCanvas;
    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            unpauseButton.gameObject.SetActive(true);
            text.text = hostText;
        }
        else
        {
            unpauseButton.gameObject.SetActive(false);
            text.text = playerText;
        }
    }

    [PunRPC] public void ClickedStart()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("DisablePause", RpcTarget.All);
        }
    }

    [PunRPC] public void DisablePause()
    {
        pauseCanvas.SetActive(false);
        //_nicknameCanvas.SetActive(false);
    }

    [PunRPC] public void Pause()
    {
        pauseCanvas.SetActive(true); //works bad but at least somehow works koroche pomogite molu
    }
}
