using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {


    #region state management
    private void SM_GoToState (PSS_PlayerShipState newState)
    {
        m_states.m_current.Exit();
        m_states.m_current = newState;
        m_states.m_current.Enter();
    }

    #endregion

    private void Update()
    {
        m_states.m_current.Update();
    }

    private void Awake()
    {
        //m_states.m_disabled = ScriptableObject.CreateInstance<PSS_Disabled>().Init(this);
        m_states.m_disabled = ScriptableObject.CreateInstance<PSS_Disabled>().Init(this) as PSS_Disabled;
        m_states.m_waiting = ScriptableObject.CreateInstance<PSS_Waiting>().Init(this) as PSS_Waiting;
        m_states.m_running = ScriptableObject.CreateInstance<PSS_Running>().Init(this) as PSS_Running;

        m_states.m_current = m_states.m_disabled;

        m_gamecontroller = FindObjectOfType<GameController>();
    }

    [SerializeField]
    PlayerShipControllerStates m_states;
    [SerializeField]
    PlayerShipControllerReferences m_references;


    public GameController m_gamecontroller;

    [System.Serializable]
    public class PlayerShipControllerStates
    {
        public PSS_PlayerShipState m_current;

        public PSS_Disabled m_disabled;
        public PSS_Waiting m_waiting;
        public PSS_Running m_running;
    }

    [System.Serializable]
    public class PlayerShipControllerReferences
    {
        public Transform m_cameraAnchor;
    }
}
