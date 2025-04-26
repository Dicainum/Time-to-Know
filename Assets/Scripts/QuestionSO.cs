using UnityEngine;

[CreateAssetMenu(fileName = "QuestionSO", menuName = "Scriptable Objects/QuestionSO")]
public class QuestionSO : ScriptableObject
{
    public int points = 100;
    public string question;
    public string answer;
    public bool withImage = false;
    public Sprite Image;
    public float overrideTimer = 0;
}
