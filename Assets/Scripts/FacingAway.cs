using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FacingAway : MonoBehaviour
{
    Transform player;
    bool playerIsNear;
    [SerializeField]
    Transform[] NPCs;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private Quaternion[] NPCStartRots = new Quaternion[10];

    private void Start()
    {
        //interaction.GetComponent<Interation>();
        player = GameManager.instance.playerRef.transform;
        for(int i = 0; i < NPCs.Length; i++)
        {
            NPCStartRots[i] = NPCs[i].rotation;
        }
    }

    private void Update()
    {
        if (playerIsNear)
        {
            foreach(Transform npc in NPCs)
            {
                Vector3 direction = npc.transform.position - player.transform.position;
                Vector3 rot = Quaternion.LookRotation(direction).eulerAngles;
                npc.rotation = Quaternion.Euler(0, rot.y, 0);
            }
        }
    }

    public void FacePlayer()
    {
        foreach (Transform npc in NPCs)
        {
            Vector3 rot = Quaternion.LookRotation(player.transform.position).eulerAngles;
            npc.rotation = Quaternion.Euler(0, rot.y, 0);
        }
    }

    public void SetPlayerNear(bool yes)
    {
        playerIsNear = yes;
        if (!playerIsNear)
        {
            for (int i = 0; i < NPCs.Length; i++)
            {
                NPCs[i].rotation = NPCStartRots[i];
            }
        }
    }

}

