using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class LaneCollisions : MonoBehaviour
{

    [Header("Events")]
    public UnityEvent OnRiffCollision;

    [Header("Debug")]
    public bool ActivateConsole;

    #region Component Defaults 
    //if the GO doesn't already have it, this will automatically set it up
    private void SetUpBoxCollider(BoxCollider boxCollider){
        boxCollider.isTrigger = true;
    }
    private void SetUpRigidbody(Rigidbody rb){
        rb.useGravity = false;
    }
    #endregion

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
            OnRiffCollision.Invoke();


            Destroy(other.gameObject,0.5f); //if incoming enemy hits riff, destroy it
        }
    }
}
