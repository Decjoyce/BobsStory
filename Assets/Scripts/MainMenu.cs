using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    public float TransistionTime = 1.5f;

    public AudioSource source;
    public AudioClip Clip;

    public GameObject music;
    
    public void LoadLevel()
    {
        StartCoroutine(LevelLoadingtime(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LevelLoadingtime(int loadingTime)
    {
        anim.SetTrigger("Play");
        
        music.SetActive(false);
        Invoke(nameof(FightingSound), 2);
        
        yield return new WaitForSeconds(TransistionTime);

        SceneManager.LoadScene(loadingTime);
    }

    void FightingSound()
    {
        source.PlayOneShot(Clip);
    }
}
