using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    [SerializeField] private Transform[] startPos;
    [SerializeField] private GameObject[] mapObjs;
    [SerializeField] float skyRotate;

    private void Update()
    {
        skyRotate += Time.deltaTime /*/ 360*/;
        if (skyRotate >= 360)
        {
            skyRotate = 0;
        }

        RenderSettings.skybox.SetFloat("_Rotation", skyRotate);
    }
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
