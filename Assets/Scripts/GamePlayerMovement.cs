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

    public bool ActivateConsole;

    void Awake(){
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

    // Start is called before the first frame update
    void Start()
    {
        //todo next: grab keyboard input.. hang on this is like face with shen to get placement lol
        /*
           public void SetMoveInput(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        } roughly how you get the input from the input system
        */

    }

    // Update is called once per frame
    void Update()
    {
        // if(Keyboard.current.spaceKey.wasPressedThisFrame){
        //     Debug.Log("shoot ya shot (later)");
        // }
        if(Keyboard.current.fKey.wasPressedThisFrame){Debug.Log("F?");}
        else if(Keyboard.current.gKey.wasPressedThisFrame){Debug.Log("G?");}
        else if(Keyboard.current.hKey.wasPressedThisFrame){Debug.Log("H?");}
        else if(Keyboard.current.jKey.wasPressedThisFrame){Debug.Log("J?");}

        
    }
}
