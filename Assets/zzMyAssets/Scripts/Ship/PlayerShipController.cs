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

    public void SM_GoToStall ()
    {
        SM_GoToState(m_states.m_stall);
    }

    public void SM_GoToDisabled()
    {
        SM_GoToState(m_states.m_disabled);
    }

    public void SM_GoToRunning ()
    {
        SM_GoToState(m_states.m_running);
    }
    #endregion

    #region ship behaviours (to be called from states)
    public void AA_AddLateralForce()
    {
        float absoluteTilt = Mathf.Abs(m_references.m_meshHolder.rotation.z);

        if (absoluteTilt - m_tiltDeadZone <= 0)
        {
            if (OnNoForce != null)
                OnNoForce();
            return;
        }



        Vector3 forceDirection;
        if (m_references.m_meshHolder.rotation.z > 0)
        {
            forceDirection = -transform.right;
            if (OnForceLeft != null)
                OnForceLeft();
        }
        else
        {
            forceDirection = transform.right;
            if (OnForceRight != null)
                OnForceRight();
        }

        float forceFactor = Mathf.Lerp(0, m_lateralPerUnitAccel, (absoluteTilt - m_tiltDeadZone) / m_maxtTiltToForce);

        m_references.m_rigidbody.AddForce(forceDirection * forceFactor, ForceMode.Force);

    }
    public void AA_AddForwardForce()
    {
        if (m_references.m_rigidbody.velocity.z >= m_forwardMaxVelocity)
            return;
        m_references.m_rigidbody.AddForce(transform.forward * m_forwardAccel);

        //Debug.Log("---> " + m_references.m_rigidbody.velocity);
    }
    public bool AA_IsHoveringRoad ()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawLine(transform.position, transform.position + Vector3.down*5, Color.red, Time.deltaTime);
       
        RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.position + Vector3.down*5, out hit, m_nonHoverableSurfaces))
        if (Physics.Raycast (ray, out hit, 1, m_nonHoverableSurfaces))
        {
            if (hit.collider.tag == "RoadSurface")
            {
                return true;
            } 
            Debug.Log("-- hit another stuff " + hit.collider.name);

            return false;
        }

        Debug.Log("-- hit nothing");
        return false;
    }
    public void AA_SetShipToStall()
    {
        m_references.m_rigidbody.useGravity = true;
        m_references.m_rigidbody.constraints = RigidbodyConstraints.None;
    }
    public void AA_ResetShipStatus ()
    {
        m_totalDistance = 0;
        
        gameObject.SetActive(true);
        m_references.m_rigidbody.useGravity = false;
        m_references.m_rigidbody.velocity = Vector3.zero;
        m_references.m_rigidbody.angularVelocity = Vector3.zero;
        m_references.m_rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;

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
        m_states.m_stall = ScriptableObject.CreateInstance<PSS_Stall>().Init(this) as PSS_Stall;

        m_states.m_current = m_states.m_disabled;

        m_gamecontroller = FindObjectOfType<GameController>();


        SM_GoToDisabled();
        //m_states.m_current = m_states.m_waiting;
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
    public LayerMask m_nonHoverableSurfaces;
    public PlayerShipControllerStates m_states;


    [Header("Others")]
    public float m_totalDistance = 0;

    public PlayerShipControllerReferences m_references;

    public PlayerShipControllerStencils m_stencils;



    [HideInInspector]
    public GameController m_gamecontroller;






    public delegate void ForceLeftAction();
    public event ForceLeftAction OnForceLeft;

    public delegate void ForceRightAction();
    public event ForceRightAction OnForceRight;

    public delegate void NoForceAction();
    public event NoForceAction OnNoForce;



    [System.Serializable]
    public class PlayerShipControllerStates
    {
        public PSS_PlayerShipState m_current;

        public PSS_Disabled m_disabled;
        public PSS_Waiting m_waiting;
        public PSS_Running m_running;
        public PSS_Stall m_stall;
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
