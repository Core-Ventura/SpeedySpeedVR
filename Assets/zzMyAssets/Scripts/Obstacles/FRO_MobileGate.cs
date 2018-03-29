using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRO_MobileGate : MonoBehaviour {

    public void AwakeFromPool()
    {

        gameObject.SetActive(true);

        float normalizedStart = Random.Range(0f, 1f);
        
        //Debug.Log(" started at " + normalizedStart.ToString("N5"));
        m_animator.Play("PingPong", -1, normalizedStart);
    }

    public void SleepToPool()
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

