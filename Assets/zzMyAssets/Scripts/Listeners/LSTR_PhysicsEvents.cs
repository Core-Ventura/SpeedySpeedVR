using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSTR_PhysicsEvents : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision with " + collision.collider.name);

        if (OnCollision != null)
            OnCollision( collision);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (OnTriggerEnterEvent != null)
            OnTriggerEnterEvent(other);
        //Debug.Log("trigger ENTER from " + name);
    }

    private void OnTriggerExit (Collider other)
    {
        //Debug.Log("trigger EXIT from " + name);
    }


    public delegate void CollisionEvent(Collision collision);
    public event CollisionEvent OnCollision;

    public delegate void TriggerEnterEvent(Collider other);
    public event TriggerEnterEvent OnTriggerEnterEvent;



}
