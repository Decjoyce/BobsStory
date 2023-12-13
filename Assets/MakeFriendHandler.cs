using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MakeFriendHandler : MonoBehaviour
{
    public ClassmateType classmateType;

    [SerializeField] private GameObject makefriendUI;
    [SerializeField] private TextMeshProUGUI makefriendText;
    [SerializeField] private GameObject askButton, nevermindButton, successfulButton, failureButton;
    static int numTimesAsked;

    public void CheckIfCanMakeFriend()
    {
        if (GameManager.instance.GetStanding(classmateType.classmateType) > 10)
        {
            makefriendText.text = "Ofcourse man, do you wanna hang out later?";
            nevermindButton.SetActive(false);
            askButton.SetActive(false);
            successfulButton.SetActive(true);
        }
        else
        {
            makefriendText.text = "Fella, I barely even know you";
            nevermindButton.SetActive(false);
            askButton.SetActive(false);
            failureButton.SetActive(true);
        }
        numTimesAsked++;
    }
}
