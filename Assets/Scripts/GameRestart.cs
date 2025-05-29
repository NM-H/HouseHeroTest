using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
