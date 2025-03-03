using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 targetPosition;
    private bool isMoving = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        targetPosition = transform.position;
        Debug.Log("PlayerMovement script is running!"); // Debug log
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Debug.Log("Mouse Clicked!"); // Debug log

            if (!EventSystem.current.IsPointerOverGameObject()) // Prevent UI clicks
            {
                Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPosition.z = 0f; // Ensure player doesn't move on Z axis
                targetPosition = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
                isMoving = true;

                Debug.Log("Mouse Clicked at: " + targetPosition);
            }
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if ((Vector2)transform.position == targetPosition)
            {
                isMoving = false;
                Debug.Log("Player Reached Target: " + targetPosition);
            }
        }
    }
}
