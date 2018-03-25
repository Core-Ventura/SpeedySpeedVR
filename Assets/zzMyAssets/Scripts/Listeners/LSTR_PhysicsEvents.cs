using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSTR_PhysicsEvents : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision with " + collision.collider.name);

        if (OnCollision != null)
            OnCollision( collision);
    }

  

    public delegate void CollisionEvent(Collision collision);
    public event CollisionEvent OnCollision;



}
