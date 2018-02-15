using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSS_Running : PSS_PlayerShipState
{
    public override void Enter()
    {
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
    }



}

