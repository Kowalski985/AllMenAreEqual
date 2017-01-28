using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject PauseUI;
    private gunController player2gun;

    private bool paused = false;

	// Use this for initialization
	void Start () {
        player2gun = GameObject.Find("smallGuy").GetComponentInChildren<gunController>();
        PauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {
            player2gun.enabled = false;
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            player2gun.enabled = true;
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
	}

    public void Resume()
    {
        paused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
