using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTime : MonoBehaviour
{
    public int framesCounter;
    public int timeToLoad;
    public int sceneToLoad;
	
	// Update is called once per frame
	void Update ()
    {
        framesCounter++;
        if (framesCounter >= timeToLoad)
        {
            timeToLoad = 0;
            LoadScene();
        }
	}

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
