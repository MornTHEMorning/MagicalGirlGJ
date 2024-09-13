using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
Attached Player_Icon under HUD Prefab; makes sure HUD version of player follows in game obj. - inspired from gun implementation in shooter games
*/
public class IconFollowGamePlayer : MonoBehaviour
{
    private RectTransform iconPosition;

    [Header("References")]

    [Tooltip("Mandatory, which camera as reference")]
    public Camera cameraPerspective;


    [Tooltip("Mandatory, ref to player in game world")]
    public Transform playerGO;

    [Header("Events")]
    
    public UnityEvent OnStartLaneSwitch;
    public UnityEvent OnLaneSwitching;

    public UnityEvent OnEndLaneSwitch;

    public UnityEvent OnNoPlayerOnscreen;

    [Header("Debug")]
    public bool ActivateConsole;

    internal void Start()
    {
        if(!playerGO || !cameraPerspective){
            Debug.Log($"{nameof(iconPosition)} requires reference to Game World Player's location and the Camera for the perspective");
            this.enabled = false;
        }

        else{
            iconPosition = GetComponent<RectTransform>();
            if(ActivateConsole){Debug.Log($"iconPosition: {iconPosition} || player position: {playerGO.transform.position} || Camera: {nameof(cameraPerspective)}");}
        }
    }

    internal void Update()
    {
        if(ActivateConsole){Debug.Log($"iconPosition: {iconPosition} || player position: {playerGO.transform.position}");}
        //https://docs.unity3d.com/ScriptReference/Camera.WorldToScreenPoint.html 
        GetComponent<RectTransform>().position = cameraPerspective.WorldToScreenPoint(playerGO.position);


    
    }
}
