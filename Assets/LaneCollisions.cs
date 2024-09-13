using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneCollisions : MonoBehaviour
{
    public bool ActivateConsole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //comes with the IsTrigger on the collider (TODO: Set the OnTrigger -> BoxCollider on unity file)
    internal void OnTriggerEnter(Collider other){
        if(ActivateConsole){Debug.Log("Collision occured!");}

        //https://www.youtube.com/watch?v=mkErt53EEFY - from this video
        if(other.gameObject.CompareTag("Enemy")){
            if(ActivateConsole){Debug.Log("Obstacle is being destroyed rn");}
            Destroy(other.gameObject,0.5f); //if it hits the riff, destroy yourself
        }
    }
}
