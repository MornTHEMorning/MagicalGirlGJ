using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class GamePlayerShooting : MonoBehaviour
{


    #region Variables
    public Player playerInputMap;
    private InputAction shoot;
    #endregion


    #region Console Stuff 
    [Header("Debug")]
    public bool ActivateConsole = false;
    #endregion


    internal void Awake(){
        playerInputMap = new Player(); 
    }

    private void OnEnable(){
        shoot = playerInputMap.PlayerInputs.Shooting;
        shoot.Enable();

        if(ActivateConsole){
                Debug.Log("Shooting Enabled");
       }
    }

    private void OnDisable(){
       shoot.Enable();

        if(ActivateConsole){
                Debug.Log("Shooting Disabled");
       }
    }


    internal void Start()
    {


    }

    internal void Update()
    {
        // if(Keyboard.current.spaceKey.wasPressedThisFrame){
        //     Debug.Log("shoot ya shot");
        // }
        if(shoot.triggered){
            Debug.Log("huh");

        }
        
    }
}
