using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenuController : SimpleMenuController
{


  
    public void AA_SetScoreText (float newScore)
    {
        foreach (Text item in m_scoreTexts)
            item.text = newScore.ToString ("N0");
    }


    
    [SerializeField]
    Text[] m_scoreTexts;
}
