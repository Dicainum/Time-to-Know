using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEditor;

#if UNITY_EDITOR
public class ThemeTest : MonoBehaviour
{
    private TMP_Text[] themes;

    private void FindThemes()
    {
        var allThemes = GameObject.FindGameObjectsWithTag("Theme");
        List<TMP_Text> themeList = new List<TMP_Text>();

        foreach (var obj in allThemes)
        {
            var textComponent = obj.GetComponent<TMP_Text>();
            if (textComponent != null)
            {
                themeList.Add(textComponent);
            }
        }

        themes = themeList.ToArray();
    }

    private void TestTheme()
    {
        if (themes == null || themes.Length == 0)
        {
            Debug.LogWarning("No themes found to test.");
            return;
        }

        for (int i = 0; i < themes.Length; i++)
        {
            string trimmedTextI = themes[i].text.Trim();

            for (int j = i + 1; j < themes.Length; j++)
            {
                string trimmedTextJ = themes[j].text.Trim();

                if (trimmedTextI == trimmedTextJ)
                {
                    Debug.LogError($"Duplicate theme found: \"{trimmedTextI}\" at indices {i} and {j}");
                }
            }
        }
    }

    [MenuItem("AutoTests/ThemeTest")]
    private void RunTest()
    {
        FindThemes();
        TestTheme();
    }
}
#endif