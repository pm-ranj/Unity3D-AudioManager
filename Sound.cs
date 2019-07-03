using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{

    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 4f)]
    public float pitch;

    public String name;

    [HideInInspector]
    public AudioSource source;

}
