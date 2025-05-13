using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

#if UNITY_EDITOR
public class QuestionTest : MonoBehaviour
{
    private static QuestionSO[] questions;

    [MenuItem("AutoTests/Questions Test")]
    private static void RunTest()
    {
        FindQuestions();
        TestQuestions();
    }

    private static void FindQuestions()
    {
        questions = Resources.LoadAll<QuestionSO>("Questions");
        Debug.Log($"Loaded {questions.Length} questions.");
    }

    private static void TestQuestions()
    {
        if (questions == null || questions.Length == 0)
        {
            Debug.LogWarning("No questions found.");
            return;
        }

        HashSet<string> seen = new HashSet<string>();
        bool hasDuplicates = false;

        for (int i = 0; i < questions.Length; i++)
        {
            string qText = questions[i].question.Trim();

            if (seen.Contains(qText))
            {
                Debug.LogError($"Duplicate question found at index {i}: \"{qText}\"");
                hasDuplicates = true;
            }
            else
            {
                seen.Add(qText);
            }
        }

        if (!hasDuplicates)
        {
            Debug.Log("All questions are unique.");
        }
    }
#endif
}