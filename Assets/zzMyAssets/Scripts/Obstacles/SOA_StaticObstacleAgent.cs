using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOA_StaticObstacleAgent : MonoBehaviour, IPoolable
{



    public virtual void AwakeFromPool()
    {
        gameObject.SetActive(true);


    }

    public virtual void SleepToPool()
    {
        gameObject.SetActive(false);


    }
}
