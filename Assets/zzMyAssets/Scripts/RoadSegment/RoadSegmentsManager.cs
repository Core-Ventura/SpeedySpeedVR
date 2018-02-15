using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSegmentsManager : MonoBehaviour {


    void ResetRSA (RoadSegmentAgent _rsa)
    {
        Debug.Log("--- one reset RSA");
        int index = m_roadSegmentAgents.IndexOf(_rsa);
        m_roadSegmentAgents.RemoveAt(index);

        m_roadSegmentAgents.Add(_rsa);
        PutLastInPosition();
       
    }



    void PutLastInPosition ()
    {
        Transform rsaToMove = m_roadSegmentAgents[m_roadSegmentAgents.Count - 1].transform;

        Vector3 offset = m_roadSegmentAgents[m_roadSegmentAgents.Count - 2].m_references.m_endpointAnchor.position - rsaToMove.position;
        rsaToMove.position += offset;
       // Debug.Log("--- element " + newRSA.name + " uses as base " + m_roadSegmentAgents[m_roadSegmentAgents.Count - 1].name);
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

            if (i > 0)
            {
                PutLastInPosition();
            }

            

        }

        

    } 

    [Header("Settings")]
    [SerializeField]
    int m_numberOfSegments;

    
    public List<RoadSegmentAgent> m_roadSegmentAgents;


    [SerializeField]
    RoadSegmentManagerStencil m_stencils;

    [System.Serializable]
    public class RoadSegmentManagerStencil
    {
        public RoadSegmentAgent m_roadSegmentAgent;
    }
}
