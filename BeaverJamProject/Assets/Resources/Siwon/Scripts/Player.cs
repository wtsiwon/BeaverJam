using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum EPlayerStat
{
    None,
    Booster,
}
public class Player : MonoBehaviour
{
    [SerializeField]
    private int posIndex;
    public int PosIndex
    {
        get => posIndex;
        set
        {
            posIndex = value;
            transform.DOMove(pos[posIndex],0.2f);
        }
    }

    public Vector3[] pos;

    public float gauge;

    public float ultDuration;

    private bool isBooster;

    public bool IsBooster
    {
        get => isBooster;
        set
        {
            isBooster = value;
        }
    }

    private void Update()
    {
        gauge += Time.deltaTime;
        Mathf.Clamp(gauge, 0, 100);

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
        if(IsBooster == true)
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
        yield return new WaitForSeconds(1f);

        gauge = 0;
        IsBooster = false;

    }
}
