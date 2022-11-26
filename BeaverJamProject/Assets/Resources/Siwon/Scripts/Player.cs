using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
public class Player : Singleton<Player>
{
    [SerializeField] private Image gaugeImg;

    [SerializeField]
    private int posIndex;
    public int PosIndex
    {
        get => posIndex;
        set
        {
            posIndex = value;
            transform.DOMove(pos[posIndex], 0.2f);
        }
    }

    public Vector3[] pos;

    [SerializeField]
    private float _gauge;
    public float gauge
    {
        get { return _gauge; }
        set
        {
            _gauge = value;
            gaugeImg.fillAmount = _gauge / 100;
            if (_gauge >= 100)
            {
                ultGaugeText.text = "Ready";
            }
            else
            {
                ultGaugeText.text = _gauge.ToString("F0") + "%";
            }
        }
    }

    public float ultDuration;

    [SerializeField]
    [Tooltip("±Ã±Ø±â °ÔÀÌÁö")]
    private TextMeshProUGUI ultGaugeText;

    private bool isBooster;
    public bool IsBooster
    {
        get => isBooster;
        set
        {
            isBooster = value;
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (GameManager.Instance.isGameStart == true)
        {
            gauge += Time.deltaTime;
        }

        SetBooter();

        InputKey();
    }



    private void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && PosIndex != 0)
        {
            PosIndex -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && PosIndex != 2)
        {
            PosIndex += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && gauge > 99 && isBooster == false)
        {
            Ultimate();
        }
    }

    private void SetBooter()
    {
        if (IsBooster == true)
        {
            GameManager.Instance.movingElementSpd = GameManager.Instance.boostingSpd;
        }
    }

    private void Ultimate()
    {
        StartCoroutine(nameof(CUltimate));
    }

    private IEnumerator CUltimate()
    {
        IsBooster = true;
        gauge = 0;

        yield return new WaitForSeconds(ultDuration);
        IsBooster = false;
    }
}
