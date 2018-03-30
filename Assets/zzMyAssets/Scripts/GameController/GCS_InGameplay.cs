using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCS_InGameplay : GCS_GameControllerState
{
    public override void Enter()
    {
        m_target.m_playerShip.SM_GoToRunning();
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
    }
}
