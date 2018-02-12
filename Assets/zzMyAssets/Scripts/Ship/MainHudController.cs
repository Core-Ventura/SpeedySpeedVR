using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHudController : MonoBehaviour {

	void Update ()
    {
        Debug.Log("--->" + m_references.m_playerShip.m_references.m_rigidbody.velocity.x);
        m_references.m_speedSlider.value = m_references.m_playerShip.m_references.m_rigidbody.velocity.z / m_references.m_playerShip.m_forwardMaxVelocity;
        AA_UpdateLateralSpeedDisplay();
    }


    private void AA_UpdateLateralSpeedDisplay ()
    {

        float normalizedSpeed = m_references.m_playerShip.m_references.m_rigidbody.velocity.x / m_references.m_playerShip.m_lateralMaxVelocity;
        if (normalizedSpeed < 0)
        {
            m_references.m_lateralSpeedSlider.value = (1 + normalizedSpeed) /2;

        } else
        {
            m_references.m_lateralSpeedSlider.value = normalizedSpeed / 2 + .5f;
        }        
    }

    private void AA_UpdateDisplayForceLeft ()
    {
        m_references.m_lateralSpeedReporter.color = Color.red;
    }

    private void AA_UpdateDisplayForceRight ()
    {
        m_references.m_lateralSpeedReporter.color = Color.green;
    }

    private void AA_UpdateDisplayNoForce ()
    {
        m_references.m_lateralSpeedReporter.color = Color.white;
    }

    public void AA_Init(PlayerShipController ownerShip)
    {
        m_references.m_playerShip = ownerShip;
        //transform.SetParent(m_references.m_playerShip.m_references.m_mainHudAnchor);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;


    }
    private void OnEnable()
    {
        m_references.m_playerShip.OnForceLeft += AA_UpdateDisplayForceLeft;
        m_references.m_playerShip.OnForceRight += AA_UpdateDisplayForceRight;
        m_references.m_playerShip.OnNoForce += AA_UpdateDisplayNoForce;
    }

    private void OnDisable()
    {
        m_references.m_playerShip.OnForceLeft -= AA_UpdateDisplayForceLeft;
        m_references.m_playerShip.OnForceRight -= AA_UpdateDisplayForceRight;
        m_references.m_playerShip.OnNoForce -= AA_UpdateDisplayNoForce;
    }

    private void Awake()
    {
        AA_Init(gameObject.GetComponentInParent<PlayerShipController>());
    }

    private void Start()
    {
        m_references.m_lateralSpeedReporter.color = Color.white;
    }


    [SerializeField]
    MainHudControllerReferences m_references;

    [System.Serializable]
    public class MainHudControllerReferences
    {
        public PlayerShipController m_playerShip;

        public Slider m_speedSlider;
        public Slider m_lateralSpeedSlider;
        public Image m_lateralSpeedReporter;
    }
}
