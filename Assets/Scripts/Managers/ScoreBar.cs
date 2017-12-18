using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBar : MonoBehaviour {

    public Scores scores;

    public float value1;
    
    void Start ()
    {
        scores = GameObject.FindGameObjectWithTag("Score").GetComponent<Scores>();
	}
	
	void Update ()
    {
        GetComponent<RectTransform>().offsetMax = new Vector2(value1, scores.bluScore);
    }
}
