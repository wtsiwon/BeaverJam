using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Spawner : MonoBehaviour
{
    [AssetList]
    private List<Obstacle> objs = new List<Obstacle>();

    public float cnt;
    public float maxCnt;

    [SerializeField] private GameObject objFolder;


    private List<GameObject> oneBlock = new List<GameObject>();
    private List<GameObject> twoBlock = new List<GameObject>();

    [SerializeField] private Transform[] spPos = new Transform[3];


    private void Start()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            GameObject go = Instantiate(objs[i]).gameObject;
            go.transform.parent = objFolder.transform;

            if (objs[i].isOneBlock) oneBlock.Add(go);
            else twoBlock.Add(go);
            go.SetActive(false);
        }        
    }

    private void ObjPop(bool isOne, Transform pos)
    {
        GameObject obj;
        if (isOne) obj = oneBlock[Random.Range(0, oneBlock.Count)];
        else obj = twoBlock[Random.Range(0, twoBlock.Count)];
        obj.SetActive(true);
        obj.transform.parent = null;
        obj.transform.position = pos.position;
        oneBlock.Remove(obj);
    }
    public void ObjPush(GameObject obstacle)
    {
        Obstacle obj = obstacle.GetComponent<Obstacle>();
        if (obj.isOneBlock) oneBlock.Add(obj.gameObject);
        else twoBlock.Add(obj.gameObject);

        obj.transform.parent = objFolder.transform;
        obj.transform.position = Vector3.zero;
        obj.gameObject.SetActive(false);
    }
    private void Update()
    {
        cnt += Time.deltaTime;
        if (cnt > maxCnt)
        {
            cnt = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        //0ÀÏ¶§ 1Ä­ Àå¾Ö¹° , 1 ÀÏ¶§ 2Ä­ 
        int ran = Random.Range(0, 2);
        bool isOneBlock = (ran == 0)? true : false;

        ObjPop(isOneBlock, spPos[Random.Range(0,3)]);
    }

}
