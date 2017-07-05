using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    [SerializeField]
    private Transform Player;        //  Transform of the Player
    [SerializeField]
    private Transform PlayerCam;     //  Transform of the Camera
    [SerializeField]
    private float throwForce;        //  Set the speed at which the object is thrown

    [SerializeField]
    private GameObject gun;

    bool hasPlayer = false;         //  Check if player is in range
    bool beingCarried = false;      //  Check if player is carrying object
    bool touched = false;           //  Check if the object that is being carried touches another object/wall

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(gameObject.transform.position, Player.position);
        if(dist <= 2.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        if(hasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = PlayerCam;
            beingCarried = true;
        }
        if (beingCarried)
        {
            gun.SetActive(false);

            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(PlayerCam.forward * throwForce);

                gun.SetActive(true);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;

                gun.SetActive(true);
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (beingCarried && col.gameObject.tag == "Wall")
        {
            touched = true;
        }
    }
}
