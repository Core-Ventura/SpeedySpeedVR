using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenuController : MonoBehaviour {


    public void AA_ShowMenu ()
    {
        //start any animation here

        transform.position = Camera.main.transform.position + Vector3.forward * m_distanceToCamera;
        transform.LookAt(Camera.main.transform.position);
        gameObject.SetActive(true);
    }
    public void AA_HideMenu ()
    {
        gameObject.SetActive(false);
    }
    public void AA_SetScoreText (float newScore)
    {
        foreach (Text item in m_scoreTexts)
            item.text = newScore.ToString ("N0");
    }


    [SerializeField]
    float m_distanceToCamera = 1;
    [SerializeField]
    Text[] m_scoreTexts;
}
