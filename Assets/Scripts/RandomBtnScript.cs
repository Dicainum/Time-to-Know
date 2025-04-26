using UnityEngine;
using UnityEngine.UI;

public class RandomBtnScript : MonoBehaviour
{
    public void SelectRandomButton()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("QuestionButton");

        if (buttons.Length == 0)
        {
            Debug.LogWarning("Кнопки с тэгом QuestionButton не найдены.");
            return;
        }

        int randomIndex = Random.Range(0, buttons.Length);
        GameObject randomButton = buttons[randomIndex];

        var buttonComponent = randomButton.GetComponent<questionButton>();
        if (buttonComponent != null)
        {
            Debug.Log("Случайно выбрана кнопка: " + randomButton.name);
            buttonComponent.LoadQuestion();
        }
    }
}
