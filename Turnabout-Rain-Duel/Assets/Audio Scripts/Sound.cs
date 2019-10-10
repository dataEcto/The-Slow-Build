﻿using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.Rendering;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    
    public AudioClip clip;

    [Range(0f,1)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
