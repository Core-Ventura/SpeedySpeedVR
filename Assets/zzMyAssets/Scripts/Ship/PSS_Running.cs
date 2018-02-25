using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSS_Running : PSS_PlayerShipState
{
    public override void Enter()
    {
        
        m_target.transform.position = m_roadSegments.m_startAnchor.transform.position;
        m_target.transform.rotation = m_roadSegments.m_startAnchor.transform.rotation;

        m_lastPosition = m_target.transform.position;
        m_target.AA_ResetShipStatus();
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {

        //Debug.Log("--->" + m_target.m_references.m_meshHolder.rotation.eulerAngles + "+++" + m_target.m_references.m_meshHolder.rotation);
        m_target.AA_AddLateralForce();
        m_target.AA_AddForwardForce();
        
    }

 
    public override void Update()
    {
        m_target.m_gamecontroller.m_mainCameraHolder.transform.position = m_target.m_references.m_cameraAnchor.transform.position;
        m_target.m_references.m_meshHolder.transform.localRotation = m_target.m_gamecontroller.m_references.m_rotationAnchor.transform.localRotation;

        Vector3 currentPosition = m_target.transform.position;
        float deltaDistance = currentPosition.z - m_lastPosition.z;
        m_target.m_totalDistance += deltaDistance;

        m_lastPosition = currentPosition;

        if (!m_target.AA_IsHoveringRoad())
        {
            m_target.SM_GoToStall();
        }

        Debug.Log(m_target.m_totalDistance);
    }

    private void Awake()
    {
        m_roadSegments = FindObjectOfType<RoadSegmentsManager>();
    }

    RoadSegmentsManager m_roadSegments;
    Vector3 m_lastPosition;


}

