using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartbeat : MonoBehaviour
{
    public float baseFrequency;
    public float minFrequency;
    public float minVolume;
    float frequency;
    public bool enableHeartBeat;
    float delay;
    float radius;
    AudioSource source;

    [SerializeField] AudioClip heatBeat;

    Transform currentTarget;
    Collider col;


    private void Start()
    {
        source = CameraManager.instance.currentCam.GetComponent<AudioSource>();
        frequency = baseFrequency;
        delay = frequency;
        col = GetComponent<Collider>();
        radius = col.bounds.extents.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enableHeartBeat)
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
                frequency = baseFrequency;
        }

        if (currentTarget == null)
            enableHeartBeat = false;
        else
            enableHeartBeat = true;

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
            source.PlayOneShot(heatBeat);
        }
    }

    void SetBeatFrequency()
    {
        float dist = Vector3.Distance(transform.position, currentTarget.position);
        float mappedDistanceForFrequency = ExtensionMethods.Map(dist, 2, radius, minFrequency, baseFrequency);
        float mappedDistanceForVolume = ExtensionMethods.Map(dist, 2, radius, 1, minVolume);

        source.volume = mappedDistanceForVolume;
        frequency = mappedDistanceForFrequency;
    }

}
