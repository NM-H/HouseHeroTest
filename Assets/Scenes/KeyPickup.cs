using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private bool canPickUp = false;
    public GameObject doorToUnlock;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Press 'E' to pick up the key.");
            canPickUp = true;
        }
    }

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Key picked up! Door unlocked.");
            Destroy(doorToUnlock); // Remove the locked door
            Destroy(gameObject); // Remove the key
        }
    }
}
