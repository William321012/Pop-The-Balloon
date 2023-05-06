using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{

    [SerializeField] int playerScore;
    [SerializeField] string playerName;
    [SerializeField] float playerDifficulty;

    public static PersistentData Instance;

    private void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(this);
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetScore(int score)
    {
        playerScore = score;
    }

    public void SetDifficulty(int difficulty)
    {
        // Difficulty has not been implemented with different leadersboards
        if (difficulty == 0) {
            playerDifficulty = 1f;
        } else if (difficulty == 1) {
            playerDifficulty = 1.5f;
        } else if (difficulty == 2) {
            playerDifficulty = 2f;
        }
    }

    public void IncrementScore(int points)
    {
        playerScore += points;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public float GetDifficulty()
    {
        return playerDifficulty;
    }
}
