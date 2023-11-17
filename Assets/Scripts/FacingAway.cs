using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEditor.Timeline;
using UnityEngine;

public class FacingAway : MonoBehaviour
{
    public Transform Player;

    public Transform NPC;

    private void Update()
    {
        Vector3 direction = NPC.transform.position - Player.transform.position;
        NPC.transform.rotation = Quaternion.LookRotation(direction); 
    }

}
