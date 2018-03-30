using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool : ScriptableObject  {

    public void AA_CreateItem ()
    {
        GameObject newItem = Instantiate(m_itemStencil);

        newItem.transform.parent = m_poolablesHolder;
        AA_SendToPool(newItem);
    }

    
    public GameObject AA_GetFromPool()
    {
        if (m_container.Count == 0)
            AA_CreateItem();

        int itemToGet = Random.Range(0, m_container.Count - 1);

        GameObject item = m_container[itemToGet];
        m_container.RemoveAt(itemToGet);
        item.GetComponent<IPoolable>().AwakeFromPool();
        return item;

    }
    
    public void AA_SendToPool (GameObject item)
    {
        IPoolable poolable = item.GetComponent<IPoolable>();
        m_container.Add(item);
        poolable.SleepToPool();
        item.transform.parent = m_poolablesHolder;
        item.transform.localPosition = Vector3.zero;

        

    }

    public void Init (Transform poolablesHolder, GameObject poolableStencil, int initialElements)
    {
        m_itemStencil = poolableStencil;
        m_poolablesHolder = poolablesHolder;
        m_container = new List<GameObject>();

        for (int i = 0; i < initialElements; i++)
        {
            AA_CreateItem();
        }
    }
    public List<GameObject> m_container;

    [SerializeField]
    public GameObject m_itemStencil;
    [SerializeField]
    Transform m_poolablesHolder;

}
