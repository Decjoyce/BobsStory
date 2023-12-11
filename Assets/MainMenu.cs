using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    public float TransistionTime = 1.5f;
    public void LoadLevel()
    {
        StartCoroutine(LevelLoadingtime(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LevelLoadingtime(int loadingTime)
    {
        anim.SetTrigger("Play");

        yield return new WaitForSeconds(TransistionTime);

        SceneManager.LoadScene(loadingTime);
    }
}
