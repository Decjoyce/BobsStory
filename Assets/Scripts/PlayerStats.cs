using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float playerHappiness;
    public float CurrentHappiness;

    [SerializeField] float minToBeHappy, minToBeNeutral, minToBeSad;

    [SerializeField] Image faceImage;
    [SerializeField] FaceManager playerFaces;

    private void Start()
    {
        CalculateHappiness();
    }

    public void CalculateHappiness()
    {
        //playerHappiness = (jocks.standing + nerds.standing + geeks.standing) / 30 * 100; //This is the average standing the player has with each classmate group as a percentage. Probs gonna change this because doing good relies on you making a lot of friends

        int highestStanding = 0;
        if (GameManager.jocksStanding > highestStanding)
            highestStanding = GameManager.jocksStanding;
        
        if(GameManager.nerdsStanding > highestStanding)
            highestStanding = GameManager.nerdsStanding;

        if (GameManager.geeksStanding > highestStanding)
            highestStanding = GameManager.geeksStanding;

        playerHappiness = highestStanding;
        CurrentHappiness = playerHappiness;

        if (playerHappiness >= minToBeHappy)
        {
            GameManager.instance.emotionalState = PlayerEmotionalState.happy;
            faceImage.sprite = playerFaces.happyFace;
        }
        else if(playerHappiness < minToBeHappy && playerHappiness >= minToBeNeutral)
        {
            GameManager.instance.emotionalState = PlayerEmotionalState.neutral;
            faceImage.sprite = playerFaces.neutralFace;
        }
        else if(playerHappiness < minToBeNeutral && playerHappiness >= minToBeSad)
        {
            GameManager.instance.emotionalState = PlayerEmotionalState.sad;
            faceImage.sprite = playerFaces.sadFace;
        }
        else if (playerHappiness < minToBeSad)
        {
            GameManager.instance.emotionalState = PlayerEmotionalState.depressed;
            faceImage.sprite = playerFaces.depressedFace;
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
