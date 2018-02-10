using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    int gameManagerData = 0;

    //public GameManagerStates m_states;

    private void Update()
    {
      //  m_states.m_currentState.StateUpdate();
    }

    private void Awake()
    {
        /*
        m_states.m_idle = ScriptableObject.CreateInstance<GMS_Idle>();
        m_states.m_idle.Init(this);

        m_states.m_ingame = ScriptableObject.CreateInstance<GMS_InGame>();
        m_states.m_ingame.Init(this);

        m_states.m_inMainMenu = ScriptableObject.CreateInstance<GMS_InMainMenu>();
        m_states.m_inMainMenu.Init(this);

        m_states.m_currentState = m_states.m_ingame;
        */
    } 
}


[System.Serializable]
public class GameManagerStates  :StatesGroup <GMS_GameManagerState>
{
    GMS_GameManagerState gmss;
    StatesGroup<GameManager> sg;

}
/*
[System.Serializable]
public class GameManagerStates
{
    public GMS_GameManagerState m_currentState;

    public GMS_Idle m_idle;
    public GMS_InGame m_ingame;
    public GMS_InMainMenu m_inMainMenu;
}
*/