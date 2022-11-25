using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum ESoundType 
{
    BGM,
    BUTTON,
    WATER,
    SKILL
}

public class SoundManager : Singleton<SoundManager>
{
    [AssetList]
    private List<AudioClip> sound = new List<AudioClip>();

    public bool bgmON;
    public bool sfxON;

    public void PlaySound(ESoundType type)
    {
        if (type == ESoundType.BGM && bgmON == false) return;
        else if (type != ESoundType.BGM && sfxON == false) return;


    }
}
