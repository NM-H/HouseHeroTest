using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel(string levelName)
    {
        LevelManagementPersist.instance.LoadLevel(levelName);
    }
}
