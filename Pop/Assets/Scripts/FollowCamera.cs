using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float interpSpeed;
    [SerializeField] Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        interpSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, interpSpeed);
    }
}
