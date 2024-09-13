using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// [RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class ForwardNotes : MonoBehaviour
{
    /*
        [x] Phase 1: attached is the "notes" -- aka obstacles; they only go towards camera, z position (decreasing) 
        [x] Phase 2: Given a specific path, it will travel in the path
        [not yet, didn't destroy itself with collision; TODO] Phase 3: Collision with back bars
            At this point, give same treatment, but make a PlayerDie script
    */

    [Tooltip("Mandatory; Lane this obstacle will travel in")]
    public Transform lanePath;
    public int speed = 1;
    
    private bool decimateSelf = false;

    [Header("Debug")]
    public bool ActivateConsole;

    private void SetUpBoxCollider(BoxCollider boxCollider){
        boxCollider.isTrigger = true;
    }

    /* ALT I wanna try - since colliders are inherited
     // private void SetUpCollider(Collider collider){
    //     collider.IsTrigger = true;
    // }
    */

    private void SetUpRigidbody(Rigidbody rb){
        rb.useGravity = false;
    }

    internal void Start()
    {
        if(!lanePath){
            Debug.Log("No lane path given -- ForwardNotes cannot run");
            this.enabled = false;
        }

        else{
            transform.position = new Vector3(lanePath.position.x, transform.position.y, transform.position.z);

            //Set up defaults, as I can't access unity rn -- want it to work when I get it up and going
            SetUpBoxCollider(GetComponent<BoxCollider>());
            // SetUpRigidbody(GetComponent<Rigidbody>());

            decimateSelf = false;
        }
    }

    internal void Update()
    {
            
            if(decimateSelf){Destroy(GetComponent<GameObject>().gameObject,0.5f);}//if it hits the riff, destroy yoursel}

            else{
                //update position
            transform.position = (transform.position - new Vector3(0,0,0.1f*speed));
            }

            // if(ActivateConsole){
            //     Debug.Log("Object: "+nameof(this.transform.parent)+" Position:"+transform.position);
            // }
    }


    //comes with the IsTrigger on the collider (TODO: Set the OnTrigger -> BoxCollider on unity file)
    internal void OnTriggerEnter(Collider other){
        if(ActivateConsole){Debug.Log("Collision occured!");}

        //https://www.youtube.com/watch?v=mkErt53EEFY - from this video
        if(other.gameObject.CompareTag("Riff")){
            if(ActivateConsole){Debug.Log("Object is being destroyed rn");}
            decimateSelf = true;
        }
    }


}
