using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FacingAway : MonoBehaviour
{
    public Transform Player;
    public Interation interaction;

    public Transform NPC;

    private void Start()
    {
        interaction.GetComponent<Interation>();
    }

    private void Update()
    {

        if(interaction.Isinteracting == true)
        {
            NPC.transform.LookAt(Player.transform.position);
        }

        else
        {
            Vector3 direction = NPC.transform.position - Player.transform.position;
            NPC.transform.rotation = Quaternion.LookRotation(direction);
        }
        
    }

}
