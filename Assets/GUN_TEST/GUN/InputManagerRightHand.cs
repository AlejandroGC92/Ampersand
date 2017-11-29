using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerRightHand : MonoBehaviour
{
    public bool trigger;
    public bool grap;
    public bool buttonA;
    public bool buttonB;
    // Use this for initialization
    void Start ()
    {
        trigger = false;
        grap = false;
        buttonA = false;
        buttonB = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            Trigger();
        }
        else trigger = false;
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            grap = true;
        }
        else grap = false;
        if (OVRInput.Get(OVRInput.Button.One))
        {
            buttonA = true;
        }
        else buttonA = false;
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            buttonB = true;
        }
        else buttonB = false;
    }

    void Trigger()
    {
        trigger = true;
    }
}
