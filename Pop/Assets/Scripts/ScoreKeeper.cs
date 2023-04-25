using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    // [SerializeField] int score;
    const int DEFAULT_POINTS = 1;
    int targetScoreCount;
    [SerializeField] Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Scene1") {
            targetScoreCount = 1;
        } else if (SceneManager.GetActiveScene().name == "Scene2") {
            targetScoreCount = 3;
        } else if (SceneManager.GetActiveScene().name == "Scene3") {
            targetScoreCount = 6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetScoreCount == PersistentData.Instance.GetScore()) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // public void AddPoints()
    // {
    //     AddPoints(DEFAULT_POINTS);
    // }

    public void AddPoints()
    {
        PersistentData.Instance.IncrementScore();
        scoreTxt.text = "Score = " + PersistentData.Instance.GetScore();
    }
}
