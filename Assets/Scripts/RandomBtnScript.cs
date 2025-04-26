using UnityEngine;
using UnityEngine.UI;

public class RandomBtnScript : MonoBehaviour
{
    public void SelectRandomButton()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("QuestionButton");

        if (buttons.Length == 0)
        {
            Debug.LogWarning("������ � ����� QuestionButton �� �������.");
            return;
        }

        int randomIndex = Random.Range(0, buttons.Length);
        GameObject randomButton = buttons[randomIndex];

        var buttonComponent = randomButton.GetComponent<questionButton>();
        if (buttonComponent != null)
        {
            Debug.Log("�������� ������� ������: " + randomButton.name);
            buttonComponent.LoadQuestion();
        }
    }
}
