using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingMenu : MonoBehaviour
{
    public LevelLoader levelLoader;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Submit")))
        {
            levelLoader.LoadLevel(1);
        }
    }
}
