using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public Animator anim;
    public Transform credits;

    private void Update()
    {
        Debug.Log(credits.transform.position.y);
       if(credits.transform.position.y <= -208)
        {
            anim.SetBool("CreditsDone", true);
        }
    }

}
