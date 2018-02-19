using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputController : MonoBehaviour {


    private void Update()
    {
        //m_gameController.m_references.m_rotationAnchor.localRotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
        m_gameController.AA_UpdateRotationAnchor(InputTracking.GetLocalRotation(XRNode.CenterEye));


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            m_gameController.IL_MainClick();

    }



    private void Awake()
    {
        m_gameController = FindObjectOfType<GameController>();
    }

    private GameController m_gameController;


}
