using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSS_Stall : PSS_PlayerShipState
{
    public override void Enter()
    {
        m_target.AA_SetShipToStall();
        m_gameController.SM_GoToScoreMenu(m_target.m_totalDistance);
        
    }

    public override void Exit()
    {
        //throw new NotImplementedException();
    }

    public override void FixedUpdate()
    {
        //throw new NotImplementedException();
    }

    public override void Update()
    {
        //throw new NotImplementedException();
    }

    private void Awake()
    {
        m_gameController = FindObjectOfType<GameController>();        
    }

    GameController m_gameController;
}
