using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ballon : MonoBehaviour
{
    [SerializeField] AudioSource pop;
    [SerializeField] float SPEED = .07f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] float BallonGrowStart = 4.0f;
    [SerializeField] float BallonGrowInterval = 2.0f;
    [SerializeField] float BallonGrowRate = 0.2f;
    private int startingScore;
    // Start is called before the first frame update
    void Start()
    {
        startingScore = PersistentData.Instance.GetScore();
        if (pop == null) {
            pop = GetComponent<AudioSource>();    
        }
        //Balloon starts growing at 4 seconds and gets larger every 2 second.
        InvokeRepeating("GrowingBalloon", BallonGrowStart, BallonGrowInterval);
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the ballon from left to right.
        transform.position = new Vector3(transform.position.x + SPEED * Time.timeScale, transform.position.y, transform.position.z);
        if (transform.position.x > 34) {
            SPEED *= -1;
            Flip();
        } else if (transform.position.x < -34) {
            SPEED *= -1;
            Flip();
        }
    }

    void GrowingBalloon() {
        transform.localScale = new Vector3((transform.localScale.x + BallonGrowRate) * PersistentData.Instance.GetDifficulty(), (transform.localScale.y + BallonGrowRate) * PersistentData.Instance.GetDifficulty(), transform.localScale.z);
        if (transform.localScale.x > 1.5) {
            AudioSource.PlayClipAtPoint(pop.clip, transform.position);
            PersistentData.Instance.SetScore(startingScore);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Flip() {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}
