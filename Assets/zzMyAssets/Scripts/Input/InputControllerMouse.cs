using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerMouse : MonoBehaviour {


    public void Update()
    {

        #region rotation tracking
        Vector3 mouseCurrentPosition = Input.mousePosition;
        Vector3 mouseDelta = mouseCurrentPosition - m_mouseLastPosition;
        
        m_rotationHelper.transform.Rotate(new Vector3(0, 0, -mouseDelta.x / 5));
        m_gameController.AA_UpdateRotationAnchor(m_rotationHelper.transform.localRotation);


        m_mouseLastPosition = mouseCurrentPosition;
        #endregion

        if (Input.GetMouseButtonDown(0))
        {
            m_gameController.IL_MainClick();
        }


    }
    private void Awake()
    {
        m_gameController = FindObjectOfType<GameController>();

        m_rotationHelper = new GameObject();
        m_rotationHelper.name = "RotationHelper";
        m_rotationHelper.transform.position = m_gameController.m_references.m_rotationAnchor.position;
        m_rotationHelper.transform.rotation = m_gameController.m_references.m_rotationAnchor.rotation;
    }

    private void Start()
    {
        m_mouseLastPosition = Input.mousePosition;
        
    }


    Vector3 m_mouseLastPosition;

    

    GameObject m_rotationHelper;
 
    private GameController m_gameController;
}
