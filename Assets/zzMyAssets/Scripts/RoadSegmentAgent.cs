using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSegmentAgent : MonoBehaviour, IPoolable {


    public void AwakeFromPool()
    {
        //here decide obstacles and load them from pools
    }

    public void SleepToPool()
    {
        gameObject.SetActive(false);

        //here send this road obstacles to obstacles pool
    }


}
