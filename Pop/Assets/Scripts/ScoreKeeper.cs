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
    [SerializeField] Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        currentPopCount = 0;
        scoreTxt.text = "Score = " + PersistentData.Instance.GetScore();
        if (SceneManager.GetActiveScene().name == "Scene1") {
            targetPopCount = 1;
        } else if (SceneManager.GetActiveScene().name == "Scene2") {
            targetPopCount = 2;
        } else if (SceneManager.GetActiveScene().name == "Scene3") {
            targetPopCount = 3;
        }
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
