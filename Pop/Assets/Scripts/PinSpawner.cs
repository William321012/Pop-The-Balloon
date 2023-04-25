using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject pin;
    [SerializeField] Vector3 pinStartLocation;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pinStartLocation = new Vector3(player.transform.position.x, player.transform.position.y-.6f, player.transform.position.z);
        if (Input.GetKeyUp(KeyCode.E)) {
            Instantiate(pin, pinStartLocation, pin.transform.rotation);
        }
    }
}
