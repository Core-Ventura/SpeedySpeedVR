using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSegmentAgent : MonoBehaviour/*, IPoolable*/ {
    
    

   public void AwakeSegment ()
    {
        //TODO:: here send obstacles to pool and  randomize a new set of obstacles!!

        if (OnResetRoadSegment != null) { 
            OnResetRoadSegment(this);
        }

        ReleaseRowAgents();
        gameObject.SetActive(true);
        SetRowAgents();

        Debug.Log("---- ONE AWAKE SEGMENT");
    }


    private void SetRowAgents ()
    {
        float step = m_references.m_mainSurface.localScale.z / m_currentRowsPerSegment;

        for (int i = 0; i < m_currentRowsPerSegment; i++)
        {
            GameObject rowGO =  PoolsManager.Instance.m_rowAgents.AA_GetFromPool();
            rowGO.transform.position = m_references.m_rowInitialAnchor.position + transform.forward * step * i;
            rowGO.transform.parent = m_references.m_rowsHolder;
            m_rows.Add(rowGO);
           
        }       
    }

    private void ReleaseRowAgents ()
    {
        foreach (GameObject item in m_rows)
        {
            item.GetComponent<RowAgent>().SleepToPool();
            PoolsManager.Instance.m_rowAgents.AA_SendToPool(item);
            
        }
        m_rows.Clear();
    }
    private void OnEnable()
    {
        m_references.m_exitLstr.OnPlayerShipPass += AwakeSegment;
    }

    private void OnDisable()
    {
        m_references.m_exitLstr.OnPlayerShipPass -= AwakeSegment;
    }


    [Header("Settings")]
    [SerializeField]
    int m_initialRowsPerSegment;



    [Header("WatchOnly")]
    [SerializeField]
    int m_currentRowsPerSegment;
    [SerializeField]
    List<GameObject> m_rows;

    public 
    RoadSegmentAgentReferences m_references;


    [System.Serializable]
    public class RoadSegmentAgentReferences
    {
        public LSTR_ShipEnters m_exitLstr;
        public Transform m_endpointAnchor;
        public Transform m_rowInitialAnchor;
        public Transform m_mainSurface;
        public Transform m_rowsHolder;
    }
    
   



    public delegate void ResetRoadStement(RoadSegmentAgent sender);
    public event ResetRoadStement OnResetRoadSegment;

}
