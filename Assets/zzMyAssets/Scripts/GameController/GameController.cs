using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameController : MonoBehaviour {

    #region state management
    private void SM_GoToState (GCS_GameControllerState newState)
    {
        m_states.m_current.Exit();
        m_states.m_current = newState;
        m_states.m_current.Enter();
    }

    public void SM_GoToScoreMenu(float scoreToShow)
    {
        m_references.m_scoreMenuController.AA_SetScoreText(scoreToShow);
        SM_GoToState(m_states.m_inScoreMenu);
    }
    public void SM_GoToMainMenu ()
    {
        SM_GoToState(m_states.m_inMainMenu);
    }
    #endregion

    #region input listeners

    public void IL_MainClick ()
    {
        if (OnMainClick != null)
            OnMainClick();
    }

    #endregion
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
        PoolsManager.Instance.testSingleton();
    }

    private void Awake()
    {
        m_states.m_inMainMenu = ScriptableObject.CreateInstance<GCS_InMainMenu>().Init(this) as GCS_InMainMenu;
        m_states.m_inGameplay = ScriptableObject.CreateInstance<GCS_InGameplay>().Init(this) as GCS_InGameplay;
        m_states.m_inScoreMenu = ScriptableObject.CreateInstance<GCS_InScoreMenu>().Init(this) as GCS_InScoreMenu;

        m_states.m_current = m_states.m_inGameplay;
    }

    [Header("Settings")]
    [SerializeField]
    float m_maxTilt = 60f;
    [SerializeField]
    float m_distanceToGuis = 1;

    [SerializeField]
    bool m_runNonStereo = false;

    public GameControllerReferences m_references;

    
    public Transform m_mainCameraHolder;

    [SerializeField]
    GameControllerStates m_states;




    public delegate void MainClickAction();
    public event MainClickAction OnMainClick;


    [System.Serializable]
    public class GameControllerReferences
    {
        public Transform m_rotationAnchor;
        public ScoreMenuController m_scoreMenuController;
    }

    [System.Serializable]
    public class GameControllerStates
    {
        public GCS_GameControllerState m_current;
        public GCS_InMainMenu m_inMainMenu;
        public GCS_InGameplay m_inGameplay;
        public GCS_InScoreMenu m_inScoreMenu;
    }
}
