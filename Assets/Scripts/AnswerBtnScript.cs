using UnityEngine;

public class AnswerBtnScript : MonoBehaviour
{
    [SerializeField] private TimerScript _resetScript;
    public void AnswerBtnClicked()
    {
        _resetScript.ResetTimer();
    }
}
