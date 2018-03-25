using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOA_Baller : SOA_StaticObstacleAgent {



    private void Start()
    {
        AwakeFromPool();
    }


    private void Update()
    {
        m_references.m_rotator.Rotate(new Vector3(0, m_rotationSpeed * Time.deltaTime, 0));
    }


    public override void AwakeFromPool()
    {
        base.AwakeFromPool();
        
        m_rotationSpeed = Random.Range(m_minimumSpeed, m_maximumSpeed) * (Random.Range(0, 2) * 2 - 1);
        m_references.m_rotator.Rotate(new Vector3 (0,Random.Range(0, m_maximumInitialOffset) * (Random.Range(0, 2) * 2 - 1),0));
    }

    #region envent handlers
    public void BallHitSomething (Collision collision)
    {
        Debug.Log(" ----BALL HIT SOMETHING ");
        if (collision.collider.tag != "Player")
            m_rotationSpeed *= -1;
    }
    #endregion


    void OnEnable()
    {
        m_references.m_phisicsListener.OnCollision += BallHitSomething;
    }


    void OnDisable()
    {
        m_references.m_phisicsListener.OnCollision -= BallHitSomething;
    }


    [SerializeField]
    float m_maximumInitialOffset = 0;
    [SerializeField]
    float m_maximumSpeed = 30;
    [SerializeField]
    float m_minimumSpeed = 10;

   [Header ("Watch only")]
   [SerializeField]
    float m_rotationSpeed = 0;



    [SerializeField]
    SOA_BallerReferences m_references;



    [System.Serializable]
    public class SOA_BallerReferences
    {
        public Transform m_rotator;

        public LSTR_PhysicsEvents m_phisicsListener;
    }

}
