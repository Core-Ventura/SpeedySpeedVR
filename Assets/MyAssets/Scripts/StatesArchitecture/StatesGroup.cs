using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesGroup <T> where T : StateBase <T>
//public class StatesGroup<T> 
{

    T m_current;

    public void GoToState (T newState)
    {
        newState.StateExit();
        m_current = newState;
        m_current.StateEnter();
    }

}
