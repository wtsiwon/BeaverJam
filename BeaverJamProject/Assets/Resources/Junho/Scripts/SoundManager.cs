using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
public enum ESoundType 
{
    BGM,
    BUTTON,
    WATER,
    SKILL,
    DIE
}

public class SoundManager : Singleton<SoundManager>
{
    [AssetList]
    [SerializeField] private List<AudioClip> sound = new List<AudioClip>();

    public bool bgmON;
    public bool sfxON;

    public AudioSource bgm;


    private void Start()
    {
        foreach(Button btn in Resources.FindObjectsOfTypeAll<Button>())
        {
            btn.onClick.AddListener(() => PlaySound(ESoundType.BUTTON));
        }

        PlaySound(ESoundType.BGM);
    }
    public void PlaySound(ESoundType type)
    {
        if (type == ESoundType.BGM && bgmON == false) return;
        else if (type != ESoundType.BGM && sfxON == false) return;

        GameObject go = new GameObject("sound");

        AudioSource audio = go.AddComponent<AudioSource>();
        audio.clip = sound[((int)type)];

        if (type == ESoundType.BGM)
        {
            bgm = audio;
            audio.loop = true;
            audio.volume = 0.2f;
        }
        audio.Play();
        if (type == ESoundType.WATER) Destroy(go, 0.5f);
        else if (type != ESoundType.BGM) Destroy(go, audio.clip.length);
    }
}
