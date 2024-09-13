using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GamePlayerMovement : MonoBehaviour
{
    // public Player playerInputMap;
    // private InputAction move;

    [Header("Events")]
    public UnityEvent OnChangeToLaneF;
    public UnityEvent OnChangeToLaneG;

    public UnityEvent OnChangeToLaneH;
    public UnityEvent OnChangeToLaneJ;


    #region Lane Positions
    [Header("Lanes to Traverse")]
    public Transform fPosition;
    public Transform gPosition;
    public Transform hPosition;
    public Transform jPosition;
    #endregion


    #region Player Defaults
    //TODO - make it so player can start from any lane
    private Vector3 defaultPlayerPosition;
    #endregion


    #region Console Stuff 
    [Header("Debug")]
    public bool ActivateConsole = false;

    #endregion
    // internal void Awake(){
    //     // playerInputMap = new Player(); 
    // }

    // private void OnEnable(){
    //     move = playerInputMap.PlayerInputs.Movement;
    //     move.Enable();

    //     if(ActivateConsole){
    //             Debug.Log("Movement Enabled");
    //    }
    // }

    // private void OnDisable(){
    //    move.Disable();
    //    if(ActivateConsole){
    //             Debug.Log("Movement Disabled");
    //    }
    // }

    internal void Start()
    {
        // check to see if lanes are there
        if(!(fPosition && gPosition && hPosition && hPosition)){
            Debug.Log("Missing lanes FGHJ position, cannot run");
            this.enabled = false;
        }

        else{
            defaultPlayerPosition = this.transform.position;
            
            //starting position is g 
            this.transform.position = new Vector3(gPosition.transform.position.x, defaultPlayerPosition.y, defaultPlayerPosition.z);
        }
    }

    internal void Update()
    {
        //TODO: the below WITH the new input system: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html
        if(Keyboard.current.fKey.wasPressedThisFrame){
            if(ActivateConsole){Debug.Log("F Key pressed");}
            OnChangeToLaneF.Invoke();

            this.transform.position = new Vector3(fPosition.transform.position.x, defaultPlayerPosition.y, defaultPlayerPosition.z);

        }
        else if(Keyboard.current.gKey.wasPressedThisFrame){
            if(ActivateConsole){Debug.Log("G Key was pressed");}
            OnChangeToLaneG.Invoke();

            this.transform.position = new Vector3(gPosition.transform.position.x, defaultPlayerPosition.y, defaultPlayerPosition.z);
        }

        else if(Keyboard.current.hKey.wasPressedThisFrame){
             if(ActivateConsole){Debug.Log("H was pressed");}
                OnChangeToLaneH.Invoke();

            this.transform.position = new Vector3(hPosition.transform.position.x, defaultPlayerPosition.y, defaultPlayerPosition.z);

        }
        else if(Keyboard.current.jKey.wasPressedThisFrame){
             if(ActivateConsole){Debug.Log("J was pressed");}
             OnChangeToLaneJ.Invoke();

            this.transform.position = new Vector3(jPosition.transform.position.x, defaultPlayerPosition.y, defaultPlayerPosition.z);
        }

        
    }
}
