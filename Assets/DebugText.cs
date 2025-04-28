using TMPro;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    [SerializeField] private AnswerBtnScript answerBtnScript;
    [SerializeField] private TMP_Text debugText;

    private void Update()
    {
        debugText.text = answerBtnScript._playerID.ToString();
    }
}
