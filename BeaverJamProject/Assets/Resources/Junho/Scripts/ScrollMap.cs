using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMap : Singleton<ScrollMap>
{
    [SerializeField] private Transform[] startPos;
    [SerializeField] private List <GameObject> mapObjs = new List<GameObject>();
    [SerializeField] float skyRotate;

    private void FixedUpdate()
    {
        skyRotate += Time.deltaTime;
        if (skyRotate >= 360)
        {
            skyRotate = 0;
        }

        RenderSettings.skybox.SetFloat("_Rotation", skyRotate);
    }

    public void NextMap(GameObject nextMap)
    {
        nextMap.transform.position =  mapObjs[mapObjs.Count - 1].transform.position + new Vector3(0,0,10);
        foreach (var item in mapObjs)
        {
            if (item == nextMap)
            {
                mapObjs.Remove(nextMap);
                break;
            }
        }
            mapObjs.Add(nextMap);
    }
}
