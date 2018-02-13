using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PoolsManager : MonoBehaviour{



    private void Awake()
    {
        m_roadSegmentPool = ScriptableObject.CreateInstance<Pool>();
        m_roadSegmentPool.Init(transform, m_stencils.m_roadSegment, 4);
    }
    private void Start()
    {
        

        Debug.Log("END");
    } 

  
    public Pool m_roadSegmentPool;



    [SerializeField]
    PoolsManagerStencils m_stencils;

    [System.Serializable]
    public class PoolsManagerStencils
    {
        public GameObject m_roadSegment;
        
    }
   
    



}
