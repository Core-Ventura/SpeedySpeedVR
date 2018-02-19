using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCS_InMainMenu : GCS_GameControllerState
{
    public override void Enter()
    {
        m_target.m_references.m_mainMenuController.AA_ShowMenu();

        m_target.OnMainClick += m_target.SM_GoToGameplay;
    }

    public override void Exit()
    {
        m_target.m_references.m_mainMenuController.AA_HideMenu();

        m_target.OnMainClick -= m_target.SM_GoToGameplay;
    }

    public override void Update()
    {
    }
}
