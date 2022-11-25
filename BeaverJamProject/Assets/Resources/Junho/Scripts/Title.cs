using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Title : Singleton<Title>
{
    [SerializeField] private TextMeshProUGUI fadeTxt;
    [SerializeField] private GameObject TitleWnd;

    [SerializeField] private Vector3 startCameraPos;
    [SerializeField] private Vector3 inGameCameraPos;
    private GameObject cameraObjs => Camera.main.gameObject;

    [SerializeField] private GameObject setWnd;
    private bool isSetOn;

    [SerializeField] private SoundManager sm = SoundManager.Instance;
    [SerializeField] private TextMeshProUGUI bgmTxt;
    [SerializeField] private TextMeshProUGUI sfxTxt;

    public GameObject pauseWnd;
    private bool isPause;

    [SerializeField] private GameObject ingameWnd;
    void Start()
    {
        isSetOn = false;
        isPause = false;

        cameraObjs.transform.position = startCameraPos;
        fadeTxt.DOFade(0f, 0.8f).SetLoops(-1, LoopType.Yoyo);
    }

    public void GoTitle()
    {
        if (isPause == true)
        {
            PauseOnBtn();
        }

        if (GameManager.Instance.spCoroutine != null) StopCoroutine(nameof(Spawner.Instance.Spawn));
        Spawner.Instance.Clear();

        ingameWnd.SetActive(false);
        TitleWnd.SetActive(true);
        cameraObjs.transform.DOMove(startCameraPos, 0.5f);
        cameraObjs.transform.DORotate(new Vector3(45, 0, 0), 0.5f);
    }
    public void StartBtn()
    {
        if (isPause == true)
        {
            PauseOnBtn();
        }
        if (GameManager.Instance.spCoroutine != null) StopCoroutine(nameof(Spawner.Instance.Spawn));
        Spawner.Instance.Clear();

        TitleWnd.SetActive(false);
        cameraObjs.transform.DOMove(inGameCameraPos, 0.5f);
        cameraObjs.transform.DORotate(new Vector3(20, 0, 0), 0.5f).OnComplete(() =>
        {
            GameManager.Instance.StartSetting();
            ingameWnd.SetActive(true);
        });

    }

    public void SettingOnBtn()
    {
        if (isSetOn == false) isSetOn = true;
        else isSetOn = false;
        setWnd.SetActive(isSetOn);
    }
    public void BgmOnBtn()
    {
        if (sm.bgmON == true)
        {
            sm.bgmON = false;
            bgmTxt.text = "BGM : OFF";
            Destroy(SoundManager.Instance.bgm);
        }
        else
        {
            sm.bgmON = true;
            bgmTxt.text = "BGM : ON";
            SoundManager.Instance.PlaySound(ESoundType.BGM);
        }
    }
    public void SfxOnBtn()
    {
        if (sm.sfxON == true)
        {
            sm.sfxON = false;
            sfxTxt.text = "SFX : OFF";
        }
        else
        {
            sm.sfxON = true;
            sfxTxt.text = "SFX : ON";
        }
    }

    public void PauseOnBtn()
    {
        if (isPause == false)
        {
            isPause = true;
            Time.timeScale = 0;
        }
        else
        {
            isPause = false;
            Time.timeScale = 1;
        }
        pauseWnd.SetActive(isPause);
    }
}
