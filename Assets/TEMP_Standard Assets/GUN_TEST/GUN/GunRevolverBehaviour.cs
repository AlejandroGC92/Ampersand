using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRevolverBehaviour : MonoBehaviour
{
    public AudioClip shoot;
    public AudioClip reload;
    public AudioSource audioSource;

    public GameObject bullet;
    public Rigidbody bulletRigidbody;
    public float bulletForce;

    public Transform gunBarrelTransform;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 6;
    public int ammo = 6;

   // private int nextTimeToFire = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        //     nextTimeToFire++;

        if ((OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && (GetComponentInParent<InputManagerRightHand>())/*&& (nextTimeToFire > fireRate)*/ && (ammo > 0)) || (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && (GetComponentInParent<InputManagerLeftHand>())/*&& (nextTimeToFire > fireRate)*/ && (ammo > 0)))
        {
   //         nextTimeToFire = 0;
            Shoot();
        }

        if (OVRInput.GetDown(OVRInput.Button.Two) && (ammo < maxAmmo))
        {
            Reload();
        }


    }

    void Shoot()
    {
        audioSource.clip = shoot;
        audioSource.Play();
        ammo -= 1;
        RaycastHit hit;

        GameObject projectile = Instantiate(bullet) as GameObject;
        projectile.transform.position = gunBarrelTransform.position;
        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.velocity = gunBarrelTransform.forward * bulletForce;
        Destroy(projectile, 2f);

        if (Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            EnemyCubeBehaviour cube = hit.transform.GetComponent<EnemyCubeBehaviour>();
            if (cube != null)
            {
                cube.TakeDamage(damage);

                Debug.DrawRay(gunBarrelTransform.position, gunBarrelTransform.TransformDirection(Vector3.forward) * 5, Color.green, 3);
            }
        }
        else Debug.DrawRay(gunBarrelTransform.position, gunBarrelTransform.TransformDirection(Vector3.forward) * 5, Color.red, 1);
    }

    void Reload()
    {
        audioSource.clip = reload;
        audioSource.Play();
        ammo = maxAmmo;
    }
}
