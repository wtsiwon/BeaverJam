using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    [SerializeField] private Transform[] startPos;
    [SerializeField] private GameObject[] mapObjs;

    private void Start()
    {
        for (int i = 0; i < mapObjs.Length; i++)
        {
            mapObjs[i].transform.position = startPos[i].position;
        }
        
    }
    public void StartSet()
    {
        for (int i = 0; i < mapObjs.Length; i++)
        {
            mapObjs[i].transform.position = startPos[i].position;
        }
    }


}
