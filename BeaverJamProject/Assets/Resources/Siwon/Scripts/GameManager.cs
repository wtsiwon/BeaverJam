using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float score;
    public float Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            UIManager.Instance.scoreText.text = score.ToString();
        }
    }

    public Coroutine spCoroutine;
    public bool isGameStart;

    [Tooltip("움직이는 요소 Spd")]
    public float movingElementSpd;

    [Tooltip("부스팅 Spd")]
    public float boostingSpd;

    public const float STARTSPD = 300f;

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
        StartCoroutine(nameof(CAddScore));
    }

    private IEnumerator CAddScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            score += movingElementSpd / 100;
            if (isGameStart == true)
            {
                if(Player.Instance.IsBooster == false && Score <= 2000)
                {
                    movingElementSpd = STARTSPD + Score / 5;
                    Mathf.Clamp(movingElementSpd, 200f, 600f);
                }
            }

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.PauseOnBtn();
        }
    }

    public void StartSetting()
    {
        if (spCoroutine != null) StopCoroutine(spCoroutine);

        Spawner.Instance.Clear();
        spCoroutine = Spawner.Instance.StartCoroutine(nameof(Spawner.Instance.Spawn));
        isGameStart = true;

    }

    public void GameOver()
    {
        StopCoroutine(spCoroutine);
        Spawner.Instance.Clear();
        isGameStart = false;
    }
}
