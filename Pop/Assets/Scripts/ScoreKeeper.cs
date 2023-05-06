using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    // [SerializeField] int score;
    // const int DEFAULT_POINTS = 1;
    [SerializeField] int targetPopCount;
    [SerializeField] public int currentPopCount;
    [SerializeField] int level;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text levelTxt;
    [SerializeField] Text directions;
    // Start is called before the first frame update
    void Start()
    {
        currentPopCount = 0;
        scoreTxt.text = "Score = " + PersistentData.Instance.GetScore();
        if (SceneManager.GetActiveScene().name == "Scene1") {
            level = 1;
            targetPopCount = 1;
            directions.text = "Find and pop " + level + " balloon.";
        } else if (SceneManager.GetActiveScene().name == "Scene2") {
            level = 2;
            targetPopCount = 2;
            directions.text = "Find and pop " + level + " balloons.";
        } else if (SceneManager.GetActiveScene().name == "Scene3") {
            level = 3;
            targetPopCount = 3;
            directions.text = "Find and pop " + level + " balloons.";
        }
        levelTxt.text = "Level " + level;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPopCount == currentPopCount) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // public void AddPoints()
    // {
    //     AddPoints(DEFAULT_POINTS);
    // }

    public void AddPoints(int points)
    {
        PersistentData.Instance.IncrementScore(points);
        scoreTxt.text = "Score = " + PersistentData.Instance.GetScore();
    }
}
