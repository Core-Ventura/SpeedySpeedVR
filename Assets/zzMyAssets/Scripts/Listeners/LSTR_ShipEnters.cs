using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSTR_ShipEnters : MonoBehaviour {


     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (OnPlayerShipPass != null)
                OnPlayerShipPass();
        }
    }


    public delegate void PlayerShipPass();
    public event PlayerShipPass OnPlayerShipPass;


}
