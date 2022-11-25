using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            transform.position = pos[posIndex];
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
            if(isBooster == true)
            {

            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && PosIndex != 0)
        {
            PosIndex -= 1; 
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && PosIndex != 2)
        {
            PosIndex += 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && gauge > 99)
        {

        }
    }

    private void SetBooter()
    {

    }

    private void Ultimate()
    {
        StartCoroutine(nameof(CUltimate));
    }

    private IEnumerator CUltimate()
    {
        IsBooster = true;

        yield return new WaitForSeconds(1f);

    }
}
