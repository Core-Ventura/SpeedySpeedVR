using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSS_Disabled : PSS_PlayerShipState
{

    public override void Enter()
    {
        Debug.Log("----->" + m_target.gameObject.name);
        m_target.gameObject.SetActive(false);
        m_target.m_references.m_audioEngine.Stop();
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
    }
}
