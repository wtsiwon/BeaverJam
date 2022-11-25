using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float point;


    public Coroutine spCoroutine;
    public bool isGameStart;

    [Tooltip("??????? ???Spd: ???, ??????")]
    public float movingElementSpd;

    [Tooltip("?¥í??? Spd")]
    public float boostingSpd;

    public GameObject pauseBoard;

    private bool isPauseBoard;
    public bool IsPauseBoard
    {
        get => isPauseBoard;
        set
        {
            isPauseBoard = value;

            pauseBoard.SetActive(isPauseBoard);
        }
    }
    private void Start()
    {
        isGameStart = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Title.Instance.PauseOnBtn();
        }
    }


    public void StartSetting()
    {
        if (spCoroutine != null) StopCoroutine(spCoroutine);

        Spawner.Instance.Clear();
        spCoroutine = Spawner.Instance.StartCoroutine(nameof(Spawner.Instance.Spawn));
    }

    public void GameOver()
    {
        StopCoroutine(spCoroutine);
        Spawner.Instance.Clear();
    }
}
