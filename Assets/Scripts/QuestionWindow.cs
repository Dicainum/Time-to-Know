using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionWindow : MonoBehaviour
{
    public string question;
    public string answer;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _answerField;
    [SerializeField] private GameObject _imageContainer;
    [SerializeField] private GameObject _questionContainer;
    [SerializeField] private Image _image;
    [SerializeField] private TimerScript _timerScript;
    public float overrideTimer;
    public bool _withImage = false;
    public Sprite sprite;
    public int points;

    public void LoadQuestionWindow()
    {
        _answerField.text = question;
        _text.text = question;
        _questionContainer.SetActive(true);
        if(_withImage )
        {
            EnablePicture();
        }
        else
        {
            _imageContainer.SetActive(false);
        }
        _timerScript.ResetTimer();
    }

    public void EnablePicture()
    {
        _image.sprite = sprite;
        _imageContainer.SetActive(true); 
        
    }

}
