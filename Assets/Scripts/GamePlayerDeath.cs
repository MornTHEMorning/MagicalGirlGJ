using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GamePlayerDeath : MonoBehaviour
{

    [Header("Events")]
    public UnityEvent OnPlayerDies; //Add HUD > Player_Icon ; Set Active . Disabled

    [Header("Debug")]
    public bool ActivateConsole;

    internal void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy")){
            if(ActivateConsole){Debug.Log("Player was hit!");}
            OnPlayerDies.Invoke();

            Destroy(this.gameObject); 
        }
    }

}
