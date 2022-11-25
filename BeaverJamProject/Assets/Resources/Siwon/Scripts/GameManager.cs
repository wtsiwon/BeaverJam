using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float point;

    public bool isGameStart;

    [Tooltip("움직이는 요소Spd: 배경, 장애물등")]
    public float movingElementSpd;

    [Tooltip("부스팅 Spd")]
    public float boostingSpd;

    public Coroutine spCoroutine;

    public bool ispauseBoard;
    private void Start()
    {
        isGameStart = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
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
