using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }


    private void Awake()
    {
        if(Instance == null)
        {
            instance = GetComponent<T>();
        }
    }

    private void OnDestroy()
    {
        instance = default(T);
    }


}
