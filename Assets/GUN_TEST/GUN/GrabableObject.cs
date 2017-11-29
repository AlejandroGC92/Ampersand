using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour {

    [Header("Options")]
    public bool replacePosition;
    public bool replaceOrientation;
    [Header("DEBUG")]
    public bool grabed;
    
	// Use this for initialization
	void Start ()
    {
        replacePosition = false;
        replaceOrientation = false;
        grabed = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
