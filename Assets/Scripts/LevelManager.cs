using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private GameObject _instance = null;
    private int currentLevel = 0;
    private string[] levelOrder = new string[]
    {
        Constants.StartScreen,
        Constants.LevelOne,
        Constants.LevelTwo,
        Constants.LevelThree,
        Constants.EndGameScreen,
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

    public void nextLevel()
    {
        currentLevel++;
        if(currentLevel >= levelOrder.Length)
        {
            Debug.Log("overran levels array, loading endScreen");
            currentLevel = levelOrder.Length - 1;
        } 
        else
        {
            Debug.Log("Loading next level");
            loadLevel(levelOrder[currentLevel]);
        }
    }

    void loadLevel(string levelName)
    {
        Debug.Log(string.Format("Loading level %s", levelName));
        SceneManager.LoadScene(levelName);
    }
}
