﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRO_MobileGate : FRO_FullRowObstacle
{

    public  override void AwakeFromPool()
    {

        gameObject.SetActive(true);

        float normalizedStart = Random.Range(0f, 1f);
        
        //Debug.Log(" started at " + normalizedStart.ToString("N5"));
        m_animator.Play("PingPong", -1, normalizedStart);
    }

    public override void SleepToPool()
    {
        gameObject.SetActive(false);
    }



    public void Awake()
    {
        AwakeFromPool();
    }

    [SerializeField]
    Animator m_animator;
}

