using UnityEngine;
using UnityEngine.UI;

public class RedScore : MonoBehaviour
{

    public Scores scores;
    public Text scoreText;

    // Use this for initialization
    void Start ()
    {
        scores = GameObject.FindGameObjectWithTag("Score").GetComponent<Scores>();
        scoreText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = scores.redScore.ToString() + "P";
	}
}
