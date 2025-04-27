using UnityEngine;
using Photon.Pun;

public class RandomBtnScript : MonoBehaviourPunCallbacks
{
    public void SelectRandomButton()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("QuestionButton");

            if (buttons.Length == 0)
            {
                //Debug.LogWarning("������ � ����� QuestionButton �� �������.");
                return;
            }

            int randomIndex = Random.Range(0, buttons.Length);
            GameObject randomButton = buttons[randomIndex];

            var buttonComponent = randomButton.GetComponent<questionButton>();
            if (buttonComponent != null)
            {
                //Debug.Log("�������� ������� ������: " + randomButton.name);
                buttonComponent.NetworkLoadQuestion();
            }  
        }
    }
}
