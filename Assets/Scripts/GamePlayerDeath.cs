using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerDeath : MonoBehaviour
{
    public bool ActivateConsole;

    internal void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy")){
            if(ActivateConsole){Debug.Log("Player was hit!");}
            Destroy(this.gameObject); 
        }
    }

}
