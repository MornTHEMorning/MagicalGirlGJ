using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GamePlayerMovement : MonoBehaviour
{
    public Player playerInputMap;
        private InputAction move;
    private InputAction shoot;

    #region Lane Positions
    public Transform fPosition;
    public Transform gPosition;
    public Transform hPosition;
    public Transform jPosition;
    #endregion

    private Vector3 defaultPlayerPosition;


    #region Console Stuff 
    private bool ActivateConsole;

    #endregion
    internal void Awake(){
        playerInputMap = new Player(); 
    }

    private void OnEnable(){
        move = playerInputMap.PlayerInputs.Movement;
        move.Enable();

        if(ActivateConsole){
                Debug.Log("Movement Enabled");
       }
    }

    private void OnDisable(){
       move.Disable();
       if(ActivateConsole){
                Debug.Log("Movement Disabled");
       }
    }

    internal void Start()
    {
        // check to see if lanes are there
        if(!(fPosition && gPosition && hPosition && hPosition)){
            Debug.Log("Missing lanes FGHJ position, cannot run");
            this.enabled = false;
        }

        else{
            defaultPlayerPosition = this.transform.position;
        }


        //todo next: grab keyboard input.. hang on this is like face with shen to get placement lol
        /*
           public void SetMoveInput(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        } roughly how you get the input from the input system
        */

    }

    internal void Update()
    {
        
        // if(Keyboard.current.spaceKey.wasPressedThisFrame){
        //     Debug.Log("shoot ya shot (later)");
        // }

        //TODO: the below WITH the new input system: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html
        if(Keyboard.current.fKey.wasPressedThisFrame){
            if(ActivateConsole){Debug.Log("F Key pressed");}
            this.transform.position = new Vector3(fPosition.transform.position.x, defaultPlayerPosition.y, defaultPlayerPosition.z);

        }
        else if(Keyboard.current.gKey.wasPressedThisFrame){
            if(ActivateConsole){Debug.Log("G Key was pressed");}
            this.transform.position = new Vector3(gPosition.transform.position.x, defaultPlayerPosition.y, defaultPlayerPosition.z);
        }

        else if(Keyboard.current.hKey.wasPressedThisFrame){
             if(ActivateConsole){Debug.Log("H was pressed");}
            this.transform.position = new Vector3(hPosition.transform.position.x, defaultPlayerPosition.y, defaultPlayerPosition.z);

        }
        else if(Keyboard.current.jKey.wasPressedThisFrame){
             if(ActivateConsole){Debug.Log("J was pressed");}
            this.transform.position = new Vector3(jPosition.transform.position.x, defaultPlayerPosition.y, defaultPlayerPosition.z);
        }

        
    }
}
