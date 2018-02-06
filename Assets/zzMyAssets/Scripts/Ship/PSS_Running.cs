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
        AA_AddLateralForce();
        AA_AddForwardForce();
        
    }

    private void AA_AddLateralForce()
    {
        float absoluteTilt = Mathf.Abs(m_target.m_references.m_meshHolder.rotation.z);

        if (absoluteTilt - m_target.m_tiltDeadZone <= 0)
            return;


        
        Vector3 forceDirection;
        if (m_target.m_references.m_meshHolder.rotation.z > 0)
            forceDirection = -m_target.transform.right;
        else
            forceDirection = m_target.transform.right;

        float forceFactor = Mathf.Lerp(0, m_target.m_lateralPerUnitAccel, (absoluteTilt - m_target.m_tiltDeadZone) / m_target.m_maxtTiltToForce);

        m_target.m_references.m_rigidbody.AddForce(forceDirection * forceFactor, ForceMode.Force);
       
    }

    private void AA_AddForwardForce ()
    {
        if (m_target.m_references.m_rigidbody.velocity.z >= m_target.m_forwardMaxVelocity)
            return;
        m_target.m_references.m_rigidbody.AddForce(m_target.transform.forward * m_target.m_forwardAccel);

        Debug.Log("---> " + m_target.m_references.m_rigidbody.velocity);
    }
    public override void Update()
    {
        
        m_target.m_gamecontroller.m_mainCameraHolder.transform.position = m_target.m_references.m_cameraAnchor.transform.position;
        m_target.m_references.m_meshHolder.transform.localRotation = m_target.m_gamecontroller.m_references.m_rotationAnchor.transform.localRotation;
        
        

    }
}
