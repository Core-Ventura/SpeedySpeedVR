using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSegmentsManager : MonoBehaviour {


    void ResetRSA (RoadSegmentAgent _rsa)
    {
        //Debug.Log("--- one reset RSA");
        int index = m_roadSegmentAgents.IndexOf(_rsa);
        m_roadSegmentAgents.RemoveAt(index);

        m_roadSegmentAgents.Add(_rsa);
        PutLastInPosition();
        //Debug.Log("---RESET RSA");
    }



    void PutLastInPosition ()
    {
        if (m_roadSegmentAgents.Count <= 1)
            return;
        Transform rsaToMove = m_roadSegmentAgents[m_roadSegmentAgents.Count - 1].transform;

        Vector3 offset = m_roadSegmentAgents[m_roadSegmentAgents.Count - 2].m_references.m_endpointAnchor.position - rsaToMove.position;
        rsaToMove.position += offset;


       // Debug.Log("--- element " + newRSA.name + " uses as base " + m_roadSegmentAgents[m_roadSegmentAgents.Count - 1].name);
    }


    public void AA_ReplaceAllSegments ()
    {
        m_roadSegmentAgents[0].transform.position = Vector3.zero;
        for (int i = 1; i <m_roadSegmentAgents.Count; i ++)
        {
            m_roadSegmentAgents[i].transform.position = m_roadSegmentAgents[i - 1].m_references.m_endpointAnchor.transform.position;
        }
    }
    private void OnEnable()
    {
        foreach (RoadSegmentAgent item in m_roadSegmentAgents)
        {
            item.OnResetRoadSegment += ResetRSA;
        }
    }


    private void OnDisable()
    {
        foreach (RoadSegmentAgent item in m_roadSegmentAgents)
        {
            item.OnResetRoadSegment -= ResetRSA;
        }
    }
    private void Start()
    {
        m_roadSegmentAgents = new List<RoadSegmentAgent>();
        for (int i = 0; i < m_numberOfSegments; i++)
        {
            RoadSegmentAgent newRSA = Instantiate(m_stencils.m_roadSegmentAgent, transform);
            newRSA.name = "RoadSegmentAgent_" + i;
            m_roadSegmentAgents.Add(newRSA);

            newRSA.OnResetRoadSegment += ResetRSA;
            newRSA.AwakeSegment();                   

        }

        

    } 

    [Header("Settings")]
    [SerializeField]
    int m_numberOfSegments;
    public Transform m_startAnchor;
    
    public List<RoadSegmentAgent> m_roadSegmentAgents;


    public RoadSegmentManagerStencil m_stencils;

    [System.Serializable]
    public class RoadSegmentManagerStencil
    {
        public RoadSegmentAgent m_roadSegmentAgent;
    }
}
