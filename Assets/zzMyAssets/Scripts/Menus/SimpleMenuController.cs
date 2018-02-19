using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMenuController : MonoBehaviour
{

    public void AA_ShowMenu()
    {
        //start any animation here

        transform.position = Camera.main.transform.position + Vector3.forward * m_distanceToCamera;
        transform.LookAt(Camera.main.transform.position);
        gameObject.SetActive(true);
    }
    public void AA_HideMenu()
    {
        gameObject.SetActive(false);
    }

    [SerializeField]
    float m_distanceToCamera = 1;
}
