using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    public void RestartGame()
    {
        GameState.Reset();
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.ClearInventory();
        }
        SceneManager.LoadScene("StartMenu");
    }
}
