using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RigidBody2D))]
[RequireComponent(typeof(BoxCollider))]
public class ForwardNotes : MonoBehaviour
{
    /*
        [x] Phase 1: attached is the "notes" -- aka obstacles; they only go towards camera, z position (decreasing) 
        [x] Phase 2: Given a specific path, it will travel in the path
        Phase 3: Collision with back bars
            At this point, give same treatment, but make a PlayerDie script
    */

    [Tooltip("Mandatory; Lane this obstacle will travel in")]
    public Transform lanePath;
    public int speed = 1;

    [Header("Debug")]
    public bool ActivateConsole;

    internal void Start()
    {
        if(!lanePath){
            Debug.Log("No lane path given -- ForwardNotes cannot run");
            this.enabled = false;
        }

        else{
            transform.position = new Vector3(lanePath.position.x, transform.position.y, transform.position.z);
        }
    }

    internal void Update()
    {
            //update position
            transform.position = (transform.position - new Vector3(0,0,0.1f*speed));

            if(ActivateConsole){
                Debug.Log("Object: "+nameof(this.transform.parent)+" Position:"+transform.position);
            }
            CheckCollision();        
    }

    //replace with OnTriggerEnter() later
    private void CheckCollision()
    {
        if(ActivateConsole){Debug.Log("Collision occured!");}
    }

}
