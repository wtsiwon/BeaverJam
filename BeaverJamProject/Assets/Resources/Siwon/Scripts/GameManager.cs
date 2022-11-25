using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float point;

    public bool isGameStart;

    public Coroutine spCoroutine;
    private void Start()
    {
        isGameStart = false;
    }

    public void StartSetting()
    {
        isGameStart = true;
        spCoroutine = StartCoroutine(Spawner.Instance.Spawn());
    }

    public void GameOver()
    {
        isGameStart = false;
        StopCoroutine(spCoroutine);
    }
}
