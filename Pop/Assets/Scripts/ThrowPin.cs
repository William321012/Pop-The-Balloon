using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPin : MonoBehaviour
{
    [SerializeField] AudioSource pop;
    [SerializeField] float SPEED = 0.13f;
    [SerializeField] Rigidbody2D rigid;
    GameObject player;
    GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null) {
            rigid = GetComponent<Rigidbody2D>();
        }

        if (pop == null) {
            pop = GetComponent<AudioSource>();    
        }

        //For some reason Find works for prelabs referencing active objects but FindByTag doesn't.
        if (player == null) {
            player = GameObject.Find("Player"); 
        }

        if (controller == null) {
            controller = GameObject.Find("GameController"); 
        }

        //Change Pin direction and rotation.
        if (player.GetComponent<Movement>().isFacingRight == false) {
            rigid.rotation += 180;
            SPEED *= -1;
        }
    }

    // Update is called once per frame.
    void Update()
    {
        //Moves Pin.
        rigid.position = new Vector2(rigid.position.x + SPEED, transform.position.y);
        Delete();
    }

    //Deletes object once they're off screen.
    private void Delete() {
        if (transform.position.x > 80) {
            Destroy(gameObject);
        } else if (transform.position.x < -80) {
            Destroy(gameObject);
        }
    }

    //Detects if pin touched balloon.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Balloon"){
            AudioSource.PlayClipAtPoint(pop.clip, transform.position);
            if (collision.gameObject.transform.localScale.x < .8f) {
                controller.GetComponent<ScoreKeeper>().AddPoints(3);
            } else if (collision.gameObject.transform.localScale.x < 1.2f) {
                controller.GetComponent<ScoreKeeper>().AddPoints(2);  
            } else if (collision.gameObject.transform.localScale.x < 1.5f) {
                controller.GetComponent<ScoreKeeper>().AddPoints(1);  
            }
            Debug.Log(controller.GetComponent<ScoreKeeper>().currentPopCount);
            controller.GetComponent<ScoreKeeper>().currentPopCount = controller.GetComponent<ScoreKeeper>().currentPopCount+1; 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
