using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCS_InScoreMenu : GCS_GameControllerState {

    public override void Enter()
    {
        m_target.m_references.m_scoreMenuController.AA_ShowMenu();

        m_target.OnMainClick += m_target.SM_GoToMainMenu;
    }

    public override void Exit()
    {

        m_target.m_references.m_scoreMenuController.AA_HideMenu();

        m_target.OnMainClick -= m_target.SM_GoToMainMenu;
    }

    public override void Update()
    {
      
    }
}
