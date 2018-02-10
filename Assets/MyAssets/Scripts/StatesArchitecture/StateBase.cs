using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class StateBase <T> : ScriptableObject
{    
    public abstract void StateEnter();
    public abstract void StateExit();
    public abstract void StateUpdate();

    public void Init (T _target)
    {
        m_target = _target;
    }

    T m_target;

}
