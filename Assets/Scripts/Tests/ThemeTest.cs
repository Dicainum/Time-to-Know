using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEditor;

#if UNITY_EDITOR
public class ThemeTest : MonoBehaviour
{
    private static TMP_Text[] themes;

    private static void FindThemes()
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

    private static void TestTheme()
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
                    return;
                }
            }
        }
        Debug.Log("All themes are unique");
    }

    [MenuItem("AutoTests/ThemeTest")]
    public static void RunTest()
    {
        FindThemes();
        TestTheme();
    }
}
#endif