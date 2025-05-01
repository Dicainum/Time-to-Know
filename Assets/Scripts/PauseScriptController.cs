using System.Linq;
using Photon.Pun;
using TMPro;
using UnityEngine;
public class PauseScriptController : MonoBehaviourPun
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private string hostText;
    [SerializeField] private string playerText;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject  _nicknameCanvas;
    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            pauseButton.gameObject.SetActive(true);
            text.text = hostText;
        }
        else
        {
            pauseButton.gameObject.SetActive(false);
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
        _nicknameCanvas.SetActive(false);
    }
}
