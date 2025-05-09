using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveGameScript : MonoBehaviour
{
    [SerializeField] public string Menu;

    public void BackToMenu()
    {
        SceneManager.LoadScene(Menu);
    }
}
