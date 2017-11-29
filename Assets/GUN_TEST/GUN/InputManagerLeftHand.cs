using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerLeftHand : MonoBehaviour
{
    public bool trigger;
    public bool grap;
    public bool buttonA;
    public bool buttonB;
    // Use this for initialization
    void Start()
    {
        trigger = false;
        grap = false;
        buttonA = false;
        buttonB = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            trigger = true;
        }
        else trigger = false;
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            grap = true;
        }
        else grap = false;
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            buttonA = true;
        }
        else buttonA = false;
        if (OVRInput.Get(OVRInput.Button.Four))
        {
            buttonB = true;
        }
        else buttonB = false;

    }
}
