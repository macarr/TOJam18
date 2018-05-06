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
            nextLevel();
        }
        else if (Input.GetButtonDown("ResetGameCheat"))
        {
            resetGame();
        }
    }

    void resetGame()
    {
        Debug.Log("Resetting game state");
        currentLevel = 0;
        loadLevel(Constants.Title);
    }

    public void resetLevel()
    {
        Debug.Log("Reloading current level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextLevel()
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
        loadLevel(levelOrder[currentLevel]);
    }

    void loadLevel(string levelName)
    {
        Debug.Log(string.Format("Loading level {0}", levelName));
        SceneManager.LoadScene(levelName);
    }
}
