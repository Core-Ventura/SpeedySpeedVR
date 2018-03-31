
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowAgent : MonoBehaviour, IPoolable
{



    #region IPoolable
    public void AwakeFromPool()
    {
        gameObject.SetActive(true);


        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber <= m_gameController.m_rowObstacleChance)
        {
            GameObject awakenObstacle = PoolsManager.Instance.m_rowObstacles.AA_GetFromPool();
            awakenObstacle.transform.parent = m_obstacleAnchors[0];
            awakenObstacle.transform.localPosition = Vector3.zero;
            m_deployedObstacles.Add(awakenObstacle);
        }
        else
        {
            int forceFree = Random.Range(0, m_obstacleAnchors.Length - 1);

            for (int i = 0; i < m_obstacleAnchors.Length; i++)
            {
                if (forceFree == i)
                    continue;
                if (Random.Range(0, 100) <= m_obstacleProbability)
                {
                    GameObject awakenStaticObstacle = PoolsManager.Instance.m_staticObstacles.AA_GetFromPool();
                    awakenStaticObstacle.transform.parent = m_obstacleAnchors[i];
                    awakenStaticObstacle.transform.localPosition = Vector3.zero;
                    m_deployedObstacles.Add(awakenStaticObstacle);
                }

            }
        }
    }

    public void SleepToPool()
    {
        gameObject.SetActive(false);
        for (int i = 0; i < m_deployedObstacles.Count; i++)
        {
            if (m_deployedObstacles[i].GetComponent<SOA_StaticObstacleAgent>() != null)
                PoolsManager.Instance.m_staticObstacles.AA_SendToPool(m_deployedObstacles[i]);
            else
                PoolsManager.Instance.m_rowObstacles.AA_SendToPool(m_deployedObstacles[i]);
        }

        m_deployedObstacles.Clear();

        if (m_obstacleProbability < 100)
            m_obstacleProbability += 2f;

    }
    #endregion


    private void Awake()
    {
        m_gameController = FindObjectOfType<GameController>();   
    }
    [Header("Settings")]
    [SerializeField]
    float m_obstacleProbability = 50;
    [Header ("References")]
    [SerializeField]
    Transform [] m_obstacleAnchors;

    GameController m_gameController;

   public List<GameObject> m_deployedObstacles = new List<GameObject>(); 
}
