using Photon.Pun;
using TMPro;
using UnityEngine;
public class PauseScriptController : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private string hostText;
    [SerializeField] private string playerText;
    [SerializeField] private TMP_Text text;
    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            pauseButton.gameObject.SetActive(true);
            text.text = hostText;
        }
        else
        {
            text.text = playerText;
        }
    }
}
