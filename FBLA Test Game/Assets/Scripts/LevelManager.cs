using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private string LastLevelLoaded;
    private int nextLevel;

    public void LoadNextLevel ()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        //LastLevelLoaded = nextLevel.ToString();
        SceneManager.LoadScene(nextLevel);
    }

	public void LoadLevel (string name)
    {
        LastLevelLoaded = name;
        if (name == "Quit")
        {
            QuitGame();
        }
        else
        {
            SceneManager.LoadScene(name);
        }
	}
	public void QuitGame ()
    {
		Application.Quit ();
	}
}
