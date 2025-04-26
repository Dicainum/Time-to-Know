using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float remainingTime;
    [SerializeField] private RandomBtnScript _randomScript;
    [SerializeField] private AnswerBtnScript _answerButtonScript;
    private bool timerEnded = false;
    [SerializeField] private GameObject _questionWindow;

    private void FixedUpdate()
    {
        if (timerEnded) return;

        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        if (seconds > 0)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = "00:00";
            TimerEnd();
        }
        
    }

    public void ResetTimer()
    {
        remainingTime = 11f;
        timerEnded = false;
    }

    private void TimerEnd()
    {
        if (_randomScript != null && remainingTime <= -0.5f && !timerEnded)
        {
            timerEnded = true;
            if(!_questionWindow.activeSelf)
            {
                _randomScript.SelectRandomButton();
            }
            else
            {
                _questionWindow.SetActive(false);
                ResetTimer();
                _answerButtonScript.ResetAnswerButton();
            }
        }
    }
}
