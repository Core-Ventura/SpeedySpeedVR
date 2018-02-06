using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameController : MonoBehaviour {


    public void AA_UpdateRotationAnchor (Quaternion _newRotation)
    {
        Quaternion newRotation = new Quaternion(m_references.m_rotationAnchor.localRotation.x, m_references.m_rotationAnchor.localRotation.y, _newRotation.z, m_references.m_rotationAnchor.localRotation.w);

        
                  
        m_references.m_rotationAnchor.localRotation = newRotation;

       
    }  

    private void Update()
    {
        //Debug.Log("---" +m_references.m_rotationAnchor.localRotation);
    }


    private void Start()
    {
        if (m_runNonStereo)
        {
            XRSettings.enabled = false;
            XRDevice.DisableAutoXRCameraTracking(Camera.main, true);
        }
          
    }

    private void Awake()
    {
       
    }

    [Header("Settings")]
    [SerializeField]
    float m_maxTilt = 60f;

    [SerializeField]
    bool m_runNonStereo = false;

    public GameControllerReferences m_references;

    
    public Transform m_mainCameraHolder;

    [System.Serializable]
    public class GameControllerReferences
    {
        public Transform m_rotationAnchor;
    }
}
