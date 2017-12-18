using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour {

    public int redScore;
    public int bluScore;
    public int days;
    
    public void RestarTiempo(int tiempo)
    {
        days -= tiempo;
        if(days <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void SumarPuntos(int redPoints, int bluPoints)
    {
        redScore += redPoints;
        bluScore += bluPoints;
    }
}
