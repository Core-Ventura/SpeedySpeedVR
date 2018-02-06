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
        throw new NotImplementedException();
    }

    public override void Update()
    {
        m_target.m_gamecontroller.m_mainCamera.transform.position = m_target.m_references.m_cameraAnchor.transform.position;
        m_target.m_references.m_meshHolder.transform.rotation = m_target.m_gamecontroller.m_references.m_rotationAnchor.transform.rotation;

    }
}
