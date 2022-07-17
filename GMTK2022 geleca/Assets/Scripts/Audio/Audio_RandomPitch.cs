using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_RandomPitch : MonoBehaviour
{
    AudioSource audioSource;
    public float cooldown = 0.07f;
    public float pitchMin = 5;
    public float pitchMax = 7;
    float lastPlay;

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomPitch()
    {
        if(Time.time - lastPlay > cooldown)
        {
        float pitch = Random.Range(pitchMin, pitchMax);
        audioSource.pitch = pitch;
        audioSource.Play();
        lastPlay = Time.time;
        }   
    }
}
