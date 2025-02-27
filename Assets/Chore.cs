using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chore : MonoBehaviour
{
    public string choreName; // Chore description
    public GameObject doorToUnlock; // Assign the door in Unity

    private bool isCompleted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCompleted)
        {
            Debug.Log("Press 'E' to complete " + choreName);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isCompleted)
        {
            CompleteChore();
        }
    }

    void CompleteChore()
    {
        isCompleted = true;
        Debug.Log(choreName + " completed! Door is now unlocked.");

        if (doorToUnlock != null)
        {
            Destroy(doorToUnlock); // Removes the door from the scene
        }

        gameObject.SetActive(false); // Hides the chore object
    }
}
