using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardNotes : MonoBehaviour
{
    //attached is the "notes" -- aka obstacles; they only go towards camera, z position (decreasing)

    private GameObject notePosition;

    public GameObject laneGO;
    private float lanePosition; //aka z value of lane

    //if debug Log is on, it'll turn on
    public bool Debug_On;


    // Start is called before the first frame update
    void Start()
    {
        notePosition = GetComponent<GameObject>();
        // laneGO = GetComponent<GameObject>();
        // float lanePosition = laneGO.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //do collision afterwards

        // if(!(notePosition.transform.position.z >= lanePosition)){
            transform.position = (transform.position - new Vector3(0,0,0.1f));
            if(Debug_On){Debug.Log("Object: "+nameof(notePosition)+" Position:"+transform.position);}
        // }
        
    }
}
