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
            UIManager.Instance.scoreText.text = score.ToString("F0");
        }
    }
    private float hScore;
    public float HScore
    {
        get { return hScore; }
        set { hScore = value; }
    }
    public Coroutine spCoroutine;
    public bool isGameStart;

    [Tooltip("�����̴� ��� Spd")]
    public float movingElementSpd;

    [Tooltip("�ν��� Spd")]
    public float boostingSpd;

    public const float STARTSPD = 2000f;

    private void Start()
    {
        isGameStart = false;
        StartCoroutine(nameof(CAddScore));
    }

    private IEnumerator CAddScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            Score += movingElementSpd / 1000;
            if (isGameStart == true)
            {
                if(Player.Instance.IsBooster == false && Score <= 20000)
                {
                    movingElementSpd = STARTSPD + Score / 5;
                    Mathf.Clamp(movingElementSpd, 2000f, 6000f);
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
        Spawner.Instance.Clear();
        StartCoroutine(Spawner.Instance.Spawn());
        isGameStart = true;
        Score = 0;
        movingElementSpd = STARTSPD;

    }

    public void GameOver()
    {
        Spawner.Instance.StopSpawn();
        Spawner.Instance.Clear();
        isGameStart = false;
        UIManager.Instance.GoTitle();
    }
}
