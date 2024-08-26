using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardNotes : MonoBehaviour
{
    //attached is the "notes" -- aka obstacles; they only go towards camer, z position (decreasing)

    private GameObject notePosition;

    //if debug Log is on, it'll turn on
    public bool Debug_On;


    // Start is called before the first frame update
    void Start()
    {
        notePosition = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //do collision afterwards

        transform.position = (transform.position - new Vector3(0,0,0.1f));
        if(Debug_On){Debug.Log(transform.position);}
        
    }
}
