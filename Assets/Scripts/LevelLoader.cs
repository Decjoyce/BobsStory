using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator anim;
    public float TransistionTime = 1.5f;

    public void LoadLevel(int index)
    {
        StartCoroutine(LevelLoadingtime(index));
    }

    IEnumerator LevelLoadingtime(int index)
    {
        anim.SetTrigger("Play");

        yield return new WaitForSeconds(TransistionTime);

        SceneManager.LoadScene(index);
    }
}
