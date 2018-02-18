using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOA_StaticObstacleAgent : MonoBehaviour, IPoolable
{



    public void AwakeFromPool()
    {
        gameObject.SetActive(true);


    }

    public void SleepToPool()
    {
        gameObject.SetActive(false);


    }
}
