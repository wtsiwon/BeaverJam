using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Title : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fadeTxt;
    [SerializeField] GameObject TitleWnd;

    [SerializeField] private Vector3 startCameraPos;
    [SerializeField] private Vector3 inGameCameraPos;
    private GameObject cameraObjs => Camera.main.gameObject;
    void Start()
    {
        cameraObjs.transform.position = startCameraPos;
        fadeTxt.DOFade(0f, 0.8f).SetLoops(-1, LoopType.Yoyo);
    }

    public void GoTitle()
    {
        TitleWnd.SetActive(true);
        cameraObjs.transform.DOMove(startCameraPos, 0.5f);
        cameraObjs.transform.DORotate(new Vector3(45, 0, 0), 0.5f);
    }
    public void StartBtn()
    {
        TitleWnd.SetActive(false);
        cameraObjs.transform.DOMove(inGameCameraPos,0.5f);
        cameraObjs.transform.DORotate(new Vector3(20, 0, 0), 0.5f);

    }
}
