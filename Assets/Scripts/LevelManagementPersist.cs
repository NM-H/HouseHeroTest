using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagementPersist : MonoBehaviour
{

    public static LevelManagementPersist instance;

    public string previousLevel;
    public string currentLevel;
    // Start is called before the first frame update 

    private void Awake()

    {
        if (instance == null)
        {
            instance = this;

            // Protect entire game object from being destroyed. This will keep ALL components on the game object
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(string levelName)
    {
        // store current scene name as previous level before loading the new scene
        previousLevel = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(levelName);

        // store newly loaded scene name as the current level
        currentLevel = levelName;
    }
}
