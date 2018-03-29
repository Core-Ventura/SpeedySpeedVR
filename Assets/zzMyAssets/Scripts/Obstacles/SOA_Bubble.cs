using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOA_Bubble : SOA_StaticObstacleAgent
{

    public override void AwakeFromPool()
    {
        #region Logic
        base.AwakeFromPool();
        gameObject.SetActive(true);
        m_armed = false;
        if (m_targetRigidbody == null)
            m_targetRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Rigidbody>();

        #endregion

        #region Visuals
        float normalizedStart = Random.Range(0f, 1f);

        Debug.Log(" started at " + normalizedStart.ToString("N5"));
        m_references.m_bubbleAnimator.Play("VerticalTiling", -1, normalizedStart);
        #endregion        
    }

    private void Update()
    {
        if (!m_armed || m_pushTime > Time.time)
            return;

        float pushForce = m_randomForces[Random.Range(0, m_randomForces.Length - 1)] * (Random.Range (0,2) * 2 -1);
        m_targetRigidbody.AddForce(m_targetRigidbody.transform.right * pushForce, ForceMode.Impulse);
        Debug.Log("----pushed X " + pushForce);
        m_armed = false;
    }

    void AA_ArmObstacle (Collider other)
    {
        if (other.tag != "Player" || m_armed == true)
            return;

        m_armed = true;
        m_pushTime = Time.time + m_pushDelay;
    }

    void OnEnable()
    {
        m_references.m_listener.OnTriggerEnterEvent += AA_ArmObstacle;
    }


    void OnDisable()
    {
        m_references.m_listener.OnTriggerEnterEvent -= AA_ArmObstacle;
    }


    private void Awake()
    {
        

    } 
    private void Start()
    {
        AwakeFromPool();
    }


    [Header("Settings")]
    [SerializeField]
    float[] m_randomForces;
    [SerializeField]
    float m_pushDelay;


    [Header("WatchOnly")]
    [SerializeField]
    bool m_armed = false;
    float m_pushTime;
    [SerializeField]
    Rigidbody m_targetRigidbody;


    [SerializeField]
    SOA_BubbleReferences m_references;
    

    [System.Serializable]
    public class SOA_BubbleReferences
    {
        
        public Animator m_bubbleAnimator;
        public LSTR_PhysicsEvents m_listener;
    }
}
