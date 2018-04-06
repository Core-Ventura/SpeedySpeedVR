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
        #region static obstacles
        m_staticObstacles = ScriptableObject.CreateInstance<Pool>();
        GameObject staticObstaclesHolder = new GameObject("StaticObstaclesHolder");
        staticObstaclesHolder.transform.parent = transform;
        m_staticObstacles.Init(staticObstaclesHolder.transform, m_stencils.m_staticObstacle.gameObject, 0);
        for (int i = 0; i<m_startingStatic; i++)
        {
            GameObject newObstacle =  Instantiate(m_stencils.m_staticObstacle.gameObject);
            m_staticObstacles.AA_SendToPool(newObstacle);
         
        }

        for (int i = 0; i < m_startingBaller; i++)
        {

            m_staticObstacles.AA_SendToPool(Instantiate(m_stencils.m_soaBaller.gameObject));
        }
        for (int i = 0; i < m_startingBubble; i++)
        {
           
            m_staticObstacles.AA_SendToPool(Instantiate(m_stencils.m_soaBubble.gameObject));

        }
        #endregion
        
        #region row obstacles
        m_rowObstacles = ScriptableObject.CreateInstance<Pool>();
        GameObject rowObstaclesHolder = new GameObject("RowObstaclesHolder");
        rowObstaclesHolder.transform.parent = transform;
        m_rowObstacles.Init(rowObstaclesHolder.transform, m_stencils.m_mobileGate.gameObject, 5);

        #endregion
        
        #region Rows 
        m_rowAgents = ScriptableObject.CreateInstance<Pool>();
        GameObject rowagentsHolder = new GameObject("RowAgentsHolder");
        rowagentsHolder.transform.parent = transform;
        m_rowAgents.Init(rowagentsHolder.transform, m_stencils.m_rowAgent.gameObject, 0);
        #endregion
    }
    public void testSingleton()
    {
        

        //Debug.Log("ENDENDENDENDENDENDEND");
    }

    [Header("Settings")]
    [SerializeField]
    int m_startingStatic;
    [SerializeField]
    int m_startingBubble;
    [SerializeField]
    int m_startingBaller;


    [Header ("Watch only")]
    public Pool m_staticObstacles;
    public Pool m_rowObstacles;
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
        public FRO_MobileGate m_mobileGate;
        public SOA_StaticObstacleAgent m_staticObstacle;
        public SOA_Baller m_soaBaller;
        public SOA_Bubble m_soaBubble;


        public RowAgent m_rowAgent;
        
    }
   
    



}
