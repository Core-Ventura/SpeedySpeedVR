using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PSS_PlayerShipState : StateGeneric<PlayerShipController>
{

    public virtual void OnCollisionEnter(){}
    public abstract void FixedUpdate();
}
