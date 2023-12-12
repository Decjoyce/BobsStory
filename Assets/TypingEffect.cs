using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TypingEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public string myText;
    private string currentText = "";
    public TextMeshProUGUI textMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());


    }

    IEnumerator ShowText()
    {
        
            for (int i = 0; i <= myText.Length; i++)
            {
                currentText = myText.Substring(0, i);
                textMesh.text = currentText;
                yield return new WaitForSeconds(delay);
            }
        
    }
   
}
