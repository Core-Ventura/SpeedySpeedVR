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

    private void FixedUpdate()
    {
        m_states.m_current.FixedUpdate();
    }
    private void Awake()
    {
        //m_states.m_disabled = ScriptableObject.CreateInstance<PSS_Disabled>().Init(this);
        m_states.m_disabled = ScriptableObject.CreateInstance<PSS_Disabled>().Init(this) as PSS_Disabled;
        m_states.m_waiting = ScriptableObject.CreateInstance<PSS_Waiting>().Init(this) as PSS_Waiting;
        m_states.m_running = ScriptableObject.CreateInstance<PSS_Running>().Init(this) as PSS_Running;

        m_states.m_current = m_states.m_disabled;

        m_gamecontroller = FindObjectOfType<GameController>();


        m_states.m_current = m_states.m_running;
    }

    private void Start()
    {
        MainHudController mainHudController = GameObject.Instantiate(m_stencils.m_mainHud, m_references.m_mainHudAnchor);

    }

    [Header("Settings")]
    public float m_tiltDeadZone = .1f;
    public float m_maxtTiltToForce = .4f;
    public float m_lateralPerUnitAccel = .5f;
    public float m_lateralMaxVelocity = 2;
    public float m_forwardAccel = 1f;
    public float m_forwardMaxVelocity = 10;

    public PlayerShipControllerStates m_states;
    
    public PlayerShipControllerReferences m_references;

    public PlayerShipControllerStencils m_stencils;
    [HideInInspector]
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
        public Transform m_meshHolder;
        public Rigidbody m_rigidbody;

        public Transform m_mainHudAnchor;
    }

    [System.Serializable]
    public class PlayerShipControllerStencils
    {
        public MainHudController m_mainHud;
    }
}
