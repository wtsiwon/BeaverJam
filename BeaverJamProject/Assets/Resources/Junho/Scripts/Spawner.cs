using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Spawner : Singleton<Spawner>
{
    [AssetList]
    [SerializeField] private List<Obstacle> objs = new List<Obstacle>();

    public float maxCnt;

    [SerializeField] private GameObject objFolder;


    private List<GameObject> oneBlock = new List<GameObject>();
    private List<GameObject> twoBlock = new List<GameObject>();

    [SerializeField] private Transform[] spPos = new Transform[3];

    [SerializeField] private List<GameObject> spawnObjs = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject go = Instantiate(objs[i]).gameObject;
                go.transform.parent = objFolder.transform;

                if (objs[i].isOneBlock)
                {
                    go.name = "OneBlock";
                    oneBlock.Add(go);
                }
                else
                {
                    go.name = "TwoBlock";
                    twoBlock.Add(go);
                }
                go.SetActive(false);
            }
        }
    }

    private GameObject CreateObj(bool isOne, int objNum)
    {
        GameObject obj = Instantiate(objs[objNum].gameObject);
        obj.transform.parent = objFolder.transform;

        if (isOne)
        {
            obj.name = "OneBlock";
            oneBlock.Add(obj);
        }
        else
        {
            obj.name = "TwoBlock";
            twoBlock.Add(obj);
        }

        obj.SetActive(false);

        return obj;
    }
    private void ObjPop(bool isOne, Transform pos)
    {
        GameObject obj;
        if (isOne)
        {
            int ranNum = Random.Range(0, oneBlock.Count);

            if (oneBlock.Count != 0) obj = oneBlock[ranNum];
            else obj = CreateObj(isOne, ranNum);
            oneBlock.Remove(obj);
        }
        else
        {
            int ranNum = Random.Range(0, twoBlock.Count);

            if (twoBlock.Count != 0) obj = twoBlock[ranNum];
            else obj = CreateObj(isOne, ranNum);
            twoBlock.Remove(obj);
            if(pos == spPos[0]) obj.transform.rotation = Quaternion.Euler(130,0,0);
            else obj.transform.rotation = Quaternion.Euler(-130,180,0);
        }
        spawnObjs.Add(obj);

        obj.SetActive(true);
        obj.transform.parent = null;
        obj.transform.position = pos.position;
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

    public void StopSpawn()
    {
        StopCoroutine(nameof(this.Spawn));
    }
    public IEnumerator Spawn()
    {
        //0ÀÏ¶§ 1Ä­ Àå¾Ö¹° , 1 ÀÏ¶§ 2Ä­ 
        int ran = Random.Range(0, 2);
        bool isOneBlock = (ran == 0)? true : false;
        if(isOneBlock == false)
        {
            //¿Þ ¿À ÀÎÁö ·£´ý Ã¼Å©
            int ranNum = Random.Range(0, 2);

            if (ranNum == 0) ObjPop(isOneBlock, spPos[0]);
            else
            {
                ObjPop(isOneBlock, spPos[2]);
            }
        }
        else ObjPop(isOneBlock, spPos[Random.Range(0,objs.Count)]);
        yield return new WaitForSeconds(maxCnt);
        GameManager.Instance.spCoroutine = this.StartCoroutine(nameof(Spawn));
    }

    public void Clear()
    {
        foreach (var item in spawnObjs)
        {
            print(item);
            ObjPush(item);
        }

        spawnObjs.Clear();
    }

    public void StopSpawn()
    {
        StopCoroutine(nameof(Spawn));
    }
}
