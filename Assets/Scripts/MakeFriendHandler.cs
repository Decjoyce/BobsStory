using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MakeFriendHandler : MonoBehaviour
{
    public ClassmateType classmateType;

    [SerializeField] private GameObject makefriendUI;
    [SerializeField] private TextMeshProUGUI makefriendText;
    [SerializeField] private GameObject askButton, nevermindButton, successfulButton, failureButton;
    [SerializeField] private Image playerFace, npcFace;
    [SerializeField] private FaceManager playerFaces, npcFaces;
    static int numTimesAsked;

    public void CheckIfCanMakeFriend()
    {
        if (GameManager.instance.GetStanding(classmateType.classmateType) > 10)
        {
            makefriendText.text = "Ofcourse man, do you wanna hang out later?";
            playerFace.sprite = playerFaces.happyFace;
            npcFace.sprite = npcFaces.happyFace;
            nevermindButton.SetActive(false);
            askButton.SetActive(false);
            successfulButton.SetActive(true);
        }
        else 
        {
            makefriendText.text = "Fella, I barely even know you";
            playerFace.sprite = playerFaces.depressedFace;
            npcFace.sprite = npcFaces.sadFace;
            nevermindButton.SetActive(false);
            askButton.SetActive(false);
            failureButton.SetActive(true);
            GameManager.instance.IncreaseStanding(classmateType.classmateType, -2);
        }
        numTimesAsked++;
    }

    public void ResetMakeFriendUI()
    {
        makefriendText.text = "What's up?";
        playerFace.sprite = playerFaces.neutralFace;
        npcFace.sprite = npcFaces.happyFace;
        nevermindButton.SetActive(true);
        askButton.SetActive(true);
        failureButton.SetActive(false);
    }

}
