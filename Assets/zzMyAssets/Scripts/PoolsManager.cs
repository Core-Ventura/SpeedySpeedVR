using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PoolsManager : Singleton <PoolsManager>
{



    private void Awake()
    {

        /*
        m_roadSegmentPool = ScriptableObject.CreateInstance<Pool>();
        m_roadSegmentPool.Init(transform, m_stencils.m_roadSegment, 4);
        */

        m_staticObstacles = ScriptableObject.CreateInstance<Pool>();
        GameObject staticObstaclesHolder = new GameObject("StaticObstaclesHolder");
        staticObstaclesHolder.transform.parent = transform;
        m_staticObstacles.Init(staticObstaclesHolder.transform, m_stencils.m_staticObstacle.gameObject, 0);


        m_rowAgents = ScriptableObject.CreateInstance<Pool>();
        GameObject rowagentsHolder = new GameObject("RowAgentsHolder");
        rowagentsHolder.transform.parent = transform;
        m_rowAgents.Init(rowagentsHolder.transform, m_stencils.m_rowAgent.gameObject, 0);
    }
    public void testSingleton()
    {
        

        //Debug.Log("ENDENDENDENDENDENDEND");
    }


    public Pool m_staticObstacles;
    public Pool m_rowAgents;

    /*
    public Pool m_roadSegmentPool;

    */
    [SerializeField]
    PoolsManagerStencils m_stencils;
    
    [System.Serializable]
    public class PoolsManagerStencils
    {
        //  public GameObject m_roadSegment;
        public SOA_StaticObstacleAgent m_staticObstacle;


        public RowAgent m_rowAgent;
        
    }
   
    



}
