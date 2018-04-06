using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SOA_Bubble : SOA_StaticObstacleAgent
{

    public override void AwakeFromPool()
    {
        #region Logic
        base.AwakeFromPool();
        gameObject.SetActive(true);
        m_armed = false;
        if (m_targetRigidbody == null)
            m_targetRigidbody = FindObjectOfType<GameController>().m_playerShip.m_references.m_rigidbody;// GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Rigidbody>();

        #endregion

        #region Visuals
        float normalizedStart = Random.Range(0f, 1f);

        //Debug.Log(" started at " + normalizedStart.ToString("N5"));
        m_references.m_bubbleAnimator.Play("VerticalTiling", -1, normalizedStart);
        #endregion

        m_references.m_arrow.rectTransform.rotation = Quaternion.identity;
        m_references.m_arrow.color = Color.white;

        int selectedForce = Random.Range(0, m_randomForces.Length);
        pushForce = m_randomForces[selectedForce] * (Random.Range(0, 2) * 2 - 1);


        #region set visual feedback
        if (pushForce > 0)
            m_references.m_arrow.rectTransform.Rotate(new Vector3(0, 0, -90));
        else
            m_references.m_arrow.rectTransform.Rotate(new Vector3(0, 0, 90));

        switch (selectedForce)
        {
            case 0:
                m_references.m_arrow.color = Color.green;
                break;
            case 1:
                m_references.m_arrow.color = Color.yellow;
                break;
            case 2:
                m_references.m_arrow.color = Color.red;
                break;
        }
        #endregion

    }

    private void Update()
    {
        if (!m_armed || m_pushTime > Time.time)
            return;
        


        m_targetRigidbody.AddForce(m_targetRigidbody.transform.right * pushForce, ForceMode.Impulse);
        m_references.m_pushAudioSource.Play();
        //Debug.Log("----pushed X " + pushForce);
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
        //AwakeFromPool();
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

    float pushForce;
    [System.Serializable]
    public class SOA_BubbleReferences
    {
        
        public Animator m_bubbleAnimator;
        public LSTR_PhysicsEvents m_listener;
        public AudioSource m_pushAudioSource;
        public Image m_arrow;
    }
}
