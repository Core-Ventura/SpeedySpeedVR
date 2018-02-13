using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GenericPool <T> where T :MonoBehaviour, IPoolable, new() {  // : new() {

    
    public T AA_GetItem ()
    {
        if (m_container.Count > 0)
        {
            T retrievedItem = m_container[0];

            m_container.RemoveAt(0);
            retrievedItem.AwakeFromPool();
            return retrievedItem;
        }

        T newItem = new T() ;
        newItem.AwakeFromPool();
        return newItem;
    }

    public void AA_ReturnItem (T returnedItem)
    {
        m_container.Add(returnedItem);
        returnedItem.SleepToPool();
    }
    


    public GenericPool (int initialElements)
    {
        for (int i = 0; i < initialElements; i ++)
        {
            T newItem = new T();
            newItem.SleepToPool();
        }
    }


    public List<T> m_container;
}
