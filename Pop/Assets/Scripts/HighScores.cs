using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public const int NUM_HIGH_SCORES = 5;
    public const string NAME_KEY = "HSPlayerName";
    public const string SCORE_KEY = "PlayerHScore";
    [SerializeField] string playerName;
    [SerializeField] int playerScore;

    [SerializeField] Text[] nameTexts;
    [SerializeField] Text[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.GetName();
        playerScore = PersistentData.Instance.GetScore();

        SavePlayerScore();
        DisplayHighScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerScore() {
        for (int i = 1; i <= NUM_HIGH_SCORES; i++) {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;

            if (PlayerPrefs.HasKey(currentScoreKey)) {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                if (playerScore > currentScore) {
                    int tempScore = currentScore;
                    string tempName = PlayerPrefs.GetString(currentNameKey);

                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentScoreKey, playerScore);

                    playerName = tempName;
                    playerScore = tempScore;
                }
            }
            else {
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                return;
            }              
        }
    }

    public void DisplayHighScores() {
        for (int i = 0; i < NUM_HIGH_SCORES; i++) {
            nameTexts[i].text = "Player Name: " + PlayerPrefs.GetString(NAME_KEY + (i+1));
            scoreTexts[i].text = "Score: " + PlayerPrefs.GetInt(SCORE_KEY + (i+1)).ToString();
        }
    }
}