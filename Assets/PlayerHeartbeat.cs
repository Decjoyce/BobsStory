using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartbeat : MonoBehaviour
{
    public float frequency;
    float delay;
    public float radius;
    AudioSource source;

    [SerializeField] AudioClip heatBeat;

    Transform currentTarget;
    Collider col;


    private void Start()
    {
        source = CameraManager.instance.currentCam.GetComponent<AudioSource>();
        delay = frequency;
        col = GetComponent<Collider>();
        radius = col.bounds.extents.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (delay <= 0)
        {
            source.PlayOneShot(heatBeat);
            delay = frequency;
        }

        delay -= Time.fixedDeltaTime;

        if (currentTarget != null)
            SetBeatFrequency();
        else
            frequency = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scary"))
        {
            currentTarget = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Scary"))
        {
            currentTarget = null;
        }
    }

    void SetBeatFrequency()
    {
        float dist = Vector3.Distance(transform.position, currentTarget.position);
        float mappedDistance = ExtensionMethods.Map(dist, 0, 10, 0.1f, 1);

        frequency = mappedDistance;
    }

}
