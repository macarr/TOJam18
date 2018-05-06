using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private static GameObject _instance = null;
    private int currentLevel = 0;
    private string[] levelOrder = new string[]
    {
        Constants.Title,
        Constants.Level1,
        Constants.Level2,
        Constants.Level3,
        Constants.Level4,
        Constants.Level5,
        Constants.Level6,
        Constants.Level7,
        Constants.Level8,
        Constants.EndScreen,
    };

    void Awake()
    {
        if (_instance == null)
        {
            _instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        if (_instance != gameObject)
            Destroy(gameObject);

    }

    private void Update()
    {
        if (Input.GetButtonDown("NextLevelCheat"))
        {
            Debug.Log("Skipped level");
            NextLevel();
        }
        else if (Input.GetButtonDown("ResetGameCheat"))
        {
            ResetGame();
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }
    }

    void ResetGame()
    {
        Debug.Log("Resetting game state");
        currentLevel = 0;
        LoadLevel(Constants.Title);
    }

    public void ResetLevel()
    {
        Debug.Log("Reloading current level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        currentLevel++;
        if(currentLevel >= levelOrder.Length)
        {
            Debug.Log("Ran off end of the array, assuming we were on the end screen and want to restart");
            currentLevel = 1;
        } 
        else
        {
            Debug.Log("Loading next level");
        }
        LoadLevel(levelOrder[currentLevel]);
    }

    void LoadLevel(string levelName)
    {
        Debug.Log(string.Format("Loading level {0}", levelName));
        SceneManager.LoadScene(levelName);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
