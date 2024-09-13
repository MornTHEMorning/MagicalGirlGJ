using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; 

namespace Dialogue{
public class DialogueSystem : MonoBehaviour
{

    //https://www.youtube.com/watch?v=8oTYabhj248 - heavily based on

    [Header("Dialogue Text")]
    [Tooltip("Place where dialogue section goes")]
    public TextMeshProUGUI textComponent; 
    public string[] lines;

    [Tooltip("Letter per speed; bigger == longer time")]
    public float textSpeed;

    [Header("Next Scene")]
    [Tooltip("Scene after this dialogue runs -- check your build settings for scene name")]

    //Get this back! -- removed for debug purposes
    // public string nextScene = "Scenes/MainScene"; //default is go to main

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();        
    }

    void Update(){

        if(Keyboard.current.spaceKey.wasPressedThisFrame){
            if(textComponent.text == lines[index]){
                NextLine();
            }

            //if there's no more left
            else{
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(index < lines.Length -1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            gameObject.SetActive(false);
            // SceneManager.LoadScene(nextScene);
        }
    }
}
}
