using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeProp : MonoBehaviour
{
    enum Tipo { Tronco, Planta, Comida }
    public int puntuacion;


    [Header("Características")]
    [SerializeField] Tipo tipo;
    public GameObject destroyed;
    public GameObject growed;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Tronco")
        {
            Destroy(other.gameObject, 0.5f);
            Destroy(this.gameObject, 0.5f);
            growed.gameObject.SetActive(true);
            destroyed.gameObject.SetActive(false);
            // ENVIAR PUNTUACION
        }
    }

    private void OnDrawGizmos()
    {
        if(tipo == 0)
        {
            Gizmos.color = new Color(1, 0.5f, 0.5f, 0.5f);
        }/*
        else if(tipo == 1)
        {
            Gizmos.color = new Color(1, 0.5f, 0.5f, 0.5f);
        }*/
        else
        {
            Gizmos.color = new Color(1, 1, 0.5f, 0.5f);
        }
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
}
