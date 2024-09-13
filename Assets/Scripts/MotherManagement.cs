using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MotherManagement : MonoBehaviour
{

    [Header("Mothers")]

    public GameObject Mother1;
    public GameObject Mother2;
    public GameObject Mother3;
    public GameObject EldrichMother;
    private GameObject currentMother;

    [Header("Events")]
    public UnityEvent MotherChangeForm;

    [Header("Debug")]
    public bool ActivateConsole;


    // Start is called before the first frame update
    void Start()
    {
        if(!(Mother1 || Mother2 || Mother3 || EldrichMother )){
            Debug.Log("Mother GO is missing -- MotherManagement cancelled");
            this.enabled = false;
        }

        else{
            currentMother = Mother1; //by default
            currentMother.SetActive(true);
        }
        
    }

    //TODO: idea is switching out the mother images, but we'll see for implementation


    public void ChangeTo1(){
        currentMother.SetActive(false);
        currentMother = Mother1;
        currentMother.SetActive(true);
        if(ActivateConsole){Debug.Log("Changed to M1");}

        MotherChangeForm.Invoke();

    }

    public void ChangeTo2(){
        currentMother.SetActive(false);
        currentMother = Mother2;
        currentMother.SetActive(true);
        if(ActivateConsole){Debug.Log("Changed to M2");}

        MotherChangeForm.Invoke();

    }

    public void ChangeTo3(){
        currentMother.SetActive(false);
        currentMother = Mother3;
        currentMother.SetActive(true);
        if(ActivateConsole){Debug.Log("Changed to M3");}

        MotherChangeForm.Invoke();

    }

    public void ChangeToEldrich(){
        currentMother.SetActive(false);
        currentMother = EldrichMother;
        currentMother.SetActive(true);
        if(ActivateConsole){Debug.Log("Changed to Eld");}

        MotherChangeForm.Invoke();

    }

}
