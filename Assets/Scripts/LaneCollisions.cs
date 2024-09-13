using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class LaneCollisions : MonoBehaviour
{
    public bool ActivateConsole;

    private void SetUpBoxCollider(BoxCollider boxCollider){
        boxCollider.isTrigger = true;
    }
    private void SetUpRigidbody(Rigidbody rb){
        rb.useGravity = false;
    }

    internal void Start()
    {
            SetUpBoxCollider(GetComponent<BoxCollider>());
            SetUpRigidbody(GetComponent<Rigidbody>());   
    }


    internal void OnTriggerEnter(Collider other){
        if(ActivateConsole){Debug.Log("Collision occured!");}

        //https://www.youtube.com/watch?v=mkErt53EEFY - from this video
        if(other.gameObject.CompareTag("Enemy")){
            if(ActivateConsole){Debug.Log("Obstacle is being destroyed rn");}
            Destroy(other.gameObject,0.5f); //if incoming enemy hits riff, destroy it
        }
    }
}
