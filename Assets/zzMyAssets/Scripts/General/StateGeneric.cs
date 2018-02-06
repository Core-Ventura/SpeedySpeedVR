using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateGeneric <T> : ScriptableObject{

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    
    public StateGeneric<T> Init ( T target)
    {
        m_target = target;
        return this;
    }
   protected T m_target;
}
