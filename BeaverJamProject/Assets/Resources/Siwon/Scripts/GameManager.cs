using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float point;


    public Coroutine spCoroutine;
    public void StartSetting()
    {
        if(spCoroutine != null) StopCoroutine(spCoroutine);

        Spawner.Instance.Clear();
        spCoroutine = StartCoroutine(Spawner.Instance.Spawn());
    }

    public void GameOver()
    {
        StopCoroutine(spCoroutine);
        Spawner.Instance.Clear();
    }
}
