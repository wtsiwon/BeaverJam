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
            if (score > 4000) Spawner.Instance.maxCnt = 1f;
            UIManager.Instance.scoreText.text = "Score: " + score.ToString("F0");
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

    public const float STARTSPD = 300f;
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("HScore", hScore);
    }
    private void Start()
    {
        hScore = PlayerPrefs.GetFloat("HScore");

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
                if(Player.Instance.IsBooster == false && Score <= 3000)
                {
                    movingElementSpd = STARTSPD + Score / 5;
                    Mathf.Clamp(movingElementSpd, 300f, 700f);
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
        isGameStart = true;
        Spawner.Instance.Clear();
        StartCoroutine(Spawner.Instance.Spawn());
        Spawner.Instance.maxCnt = 2f;
        Score = 0;
        Player.Instance.gauge = 0;
        movingElementSpd = STARTSPD;

    }

    public void GameOver()
    {
        SoundManager.Instance.PlaySound(ESoundType.DIE);
        isGameStart = false;

        Spawner.Instance.StopSpawn();
        Spawner.Instance.Clear();
        movingElementSpd = STARTSPD;
        UIManager.Instance.GoTitle();
    }
}
