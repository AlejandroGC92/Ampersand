using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;

    public Transform gunBarrelTransform;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            audioSource.Play();
            RaycastGun();
        }

        Debug.DrawRay(gunBarrelTransform.position, gunBarrelTransform.TransformDirection(Vector3.forward) * 5, Color.red, 1);
    }

    private void RaycastGun()
    {
        RaycastHit hit;

        Debug.DrawRay(gunBarrelTransform.position, gunBarrelTransform.TransformDirection(Vector3.forward) * 20, Color.green, 10);

        if (Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Cube"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
