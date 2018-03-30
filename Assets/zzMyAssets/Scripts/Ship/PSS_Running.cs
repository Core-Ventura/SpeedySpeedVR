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

        m_target.m_currentShield = m_target.m_maxShield;
        m_target.AA_ResetShipStatus();
    }

    public override void Exit()
    {
    }

    #region physics called from m_target
    public override void FixedUpdate()
    {

        //Debug.Log("--->" + m_target.m_references.m_meshHolder.rotation.eulerAngles + "+++" + m_target.m_references.m_meshHolder.rotation);
        m_target.AA_AddLateralForce();
        m_target.AA_AddForwardForce();
        
    }
    public override void OnCollisionEnter()
    {
        Debug.Log("---XXXXXship collision at velocity " + m_target.m_lastUpdateVelocity + " ---");
        m_target.AA_DrainShield(m_target.m_lastUpdateVelocity.z * 5f);
        if (m_target.m_currentShield <= 0 )
        {
            m_target.SM_GoToStall();
        }

    }

    #endregion

    public override void Update()
    {
        #region set auxiliar components position
        m_target.m_gamecontroller.m_mainCameraHolder.transform.position = m_target.m_references.m_cameraAnchor.transform.position;
        m_target.m_references.m_meshHolder.transform.localRotation = m_target.m_gamecontroller.m_references.m_rotationAnchor.transform.localRotation;
        #endregion

        #region update distance for score
        Vector3 currentPosition = m_target.transform.position;
        float deltaDistance = currentPosition.z - m_lastPosition.z;
        m_target.m_totalDistance += deltaDistance;

        m_lastPosition = currentPosition;
        #endregion

        #region call to target behaviours
        m_target.AA_RegenShield();
        #endregion


        #region check for state changes
        if (!m_target.AA_IsHoveringRoad())
        {
            m_target.SM_GoToStall();
        }

        #endregion

        

        //Debug.Log("--- " + m_target.m_references.m_rigidbody.velocity);

        //Debug.Log(m_target.m_totalDistance);
    }

    private void Awake()
    {
        m_roadSegments = FindObjectOfType<RoadSegmentsManager>();
    }



    RoadSegmentsManager m_roadSegments;
    Vector3 m_lastPosition;

    
}

