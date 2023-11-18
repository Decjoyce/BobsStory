using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartbeat : MonoBehaviour
{
    public float baseFrequency;
    public float minFrequency;
    float frequency;
    public bool enableHeatBeat;
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
        if (enableHeatBeat)
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
        float mappedDistance = ExtensionMethods.Map(dist, 1, radius, minFrequency, baseFrequency);

        frequency = mappedDistance;
    }

}
