using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float playerHappiness;

    [SerializeField] ClassmateType jocks, nerds, geeks;

    [SerializeField] float minToBeHappy, minToBeNeutral, minToBeSad;

    [SerializeField] Image faceImage;
    [SerializeField] Sprite happyFace, neutralFace, sadFace, depressedFace;

    private void Start()
    {
        CalculateHappiness();
    }

    public void CalculateHappiness()
    {
        //playerHappiness = (jocks.standing + nerds.standing + geeks.standing) / 30 * 100; //This is the average standing the player has with each classmate group as a percentage. Probs gonna change this because doing good relies on you making a lot of friends

/*        if (jocks.standing > playerHappiness)
            playerHappiness = jocks.standing;

        if (nerds.standing > playerHappiness)
            playerHappiness = nerds.standing;

        if (geeks.standing > playerHappiness)
            playerHappiness = geeks.standing;*/

        if (playerHappiness >= minToBeHappy)
        {
            GameManager.instance.emotionalState = PlayerEmotionalState.happy;
            faceImage.sprite = happyFace;
        }
        else if(playerHappiness < minToBeHappy && playerHappiness >= minToBeNeutral)
        {
            GameManager.instance.emotionalState = PlayerEmotionalState.neutral;
            faceImage.sprite = neutralFace;
        }
        else if(playerHappiness < minToBeNeutral && playerHappiness >= minToBeSad)
        {
            GameManager.instance.emotionalState = PlayerEmotionalState.sad;
            faceImage.sprite = sadFace;
        }
        else if (playerHappiness < minToBeSad)
        {
            GameManager.instance.emotionalState = PlayerEmotionalState.depressed;
            faceImage.sprite = depressedFace;
        }
    }    
    
    public enum PlayerEmotionalState
    {
        happy,
        neutral,
        sad, 
        depressed,
    }
}
