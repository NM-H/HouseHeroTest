using UnityEngine;

public class Doormat : MonoBehaviour
{
    public GameObject hiddenKey; // Assign the key in Unity
    private bool canInteract = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Press 'E' to check the doormat.");
            canInteract = true;
        }
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("You found a key under the doormat!");
            hiddenKey.SetActive(true); // Reveal the key
            gameObject.SetActive(false); // Remove the doormat
        }
    }
}
