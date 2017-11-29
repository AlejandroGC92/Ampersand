using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class NPC_Basic : MonoBehaviour
{
    enum Especie { Humano, Robot, Criatura }
    enum Faccion { Neutral, Rebelde, Autoridad } // Compara tu facción y la suya
    enum Caracter { Pasivo, Manso, Agresivo } // Como reacciona si tu facción difiere de la suya. Pasivo huye, el Manso solo ataca si tú le atacas, el Agresivo te ataca
    enum Movimiento { Estatico, Patrulla, Libre } // Cual es su modo de desplazamiento habitual. Estático siempre permanece en un mismo punto, Patrulla se mueve entre puntos y Libre vaga por el NavMesh
    enum Discurso { Asocial, Monologo, Interactuable }  // Asocial es un NPC que nunca habla, Monologuista es un NPC que nunca calla, el Interactuable es un NPC que emite un sonido si estás lejos y otro si estás cerca. 
                                                        // Generalmente este último sirve ya sea para un NPC que grita pidiendo ayuda y al acercarte te especifica para qué requiere tus servicios,
                                                        // O para un NPC que está dialogando con otro y en acercarte te pide por favor que te alejes, que eso no te incumbe.
    
    [Header("Características")]
    [SerializeField] Especie especie;
    [SerializeField] Faccion faccion;
    [SerializeField] Caracter caracter;
    [SerializeField] Movimiento movimiento;
    [SerializeField] Discurso discurso;

    [Header("Especificaciones Físicas")]
    public float targetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform fpsTarget;
    Rigidbody theRigidbody;
    Renderer myRender;

    // Use this for initialization
    void Start ()
    {
        myRender = GetComponent<Renderer>();
        theRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        targetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (targetDistance < enemyLookDistance)
        {
            myRender.material.color = Color.yellow;
            LookAtPlayer();
            if (targetDistance < attackDistance)
            {
                myRender.material.color = Color.red;
                Attack();
            }
        }
        else myRender.material.color = Color.white;
    }

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
    }

    void Attack()
    {
        theRigidbody.AddForce(transform.forward * enemyMovementSpeed);
    }
}
