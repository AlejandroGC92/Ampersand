using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public bool pauseMenuActive = false;
    public GameObject pauseMenu;
    
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            pauseMenuActive = !pauseMenuActive;
            pauseMenu.SetActive(pauseMenuActive);
        }
    }
}
