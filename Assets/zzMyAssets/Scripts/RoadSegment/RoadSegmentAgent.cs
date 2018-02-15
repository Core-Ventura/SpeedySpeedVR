using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSegmentAgent : MonoBehaviour/*, IPoolable*/ {
    
    /*
    public void AwakeFromPool()
    {
        //here decide obstacles and load them from pools
        gameObject.SetActive(true);
    }

    public void SleepToPool()
    {
        gameObject.SetActive(false);

        //here send this road obstacles to obstacles pool
    }

    */

   public void AwakeSegment ()
    {
        //TODO:: here send obstacles to pool and  randomize a new set of obstacles!!

        if (OnResetRoadSegment != null) { 
            OnResetRoadSegment(this);
        }
        gameObject.SetActive(true);
        Debug.Log("---- ONE AWAKE SEGMENT");
    }

    private void OnEnable()
    {
        m_references.m_exitLstr.OnPlayerShipPass += AwakeSegment;
    }

    private void OnDisable()
    {
        m_references.m_exitLstr.OnPlayerShipPass -= AwakeSegment;
    }


    public 
    RoadSegmentAgentReferences m_references;


    [System.Serializable]
    public class RoadSegmentAgentReferences
    {
        public LSTR_ShipEnters m_exitLstr;
        public Transform m_endpointAnchor;
    }


    public delegate void ResetRoadStement(RoadSegmentAgent sender);
    public event ResetRoadStement OnResetRoadSegment;

}
