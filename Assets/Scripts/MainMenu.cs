using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject aboutPanel;

    void Start()
    {
        aboutPanel.SetActive(false); // Hide About panel at start
    }

    public void StartGame()
    {
        SceneManager.LoadScene("OutHouse"); // Load next scene
    }

    public void ShowAbout()
    {
        aboutPanel.SetActive(true);
    }

    public void HideAbout()
    {
        aboutPanel.SetActive(false);
    }
}
