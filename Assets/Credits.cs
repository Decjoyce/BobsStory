using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Animator anim;
    public Transform credits;
    public AnimationClip clip;

    private void Start()
    {
        StartCoroutine(ShowCredits());
    }

    IEnumerator ShowCredits()
    {
        yield return new WaitForSeconds(clip.length);
        anim.SetBool("CreditsDone", true);
        SceneManager.LoadScene(0);
    }

}
