using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Migration : MonoBehaviour
{
    enum Tipo { Zona, Territorio }

    public int tiempoViaje;

    /*
    [Header("Características")]
    [SerializeField] Tipo tipo;
    */

    public GameObject player;
    public Scores scores;
    public GameObject unloadScenary;
    public GameObject loadScenary;
    public GameObject playerNewPosition;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scores = GameObject.FindGameObjectWithTag("Score").GetComponent<Scores>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            unloadScenary.gameObject.SetActive(false);
            loadScenary.gameObject.SetActive(true);
            player.transform.position = playerNewPosition.transform.position;
            scores.RestarTiempo(tiempoViaje);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0.5f, 0.5f);
        //Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
}