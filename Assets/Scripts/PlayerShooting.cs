using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    // Ammo
    // Reload
    // Delay on shooting

    [SerializeField]
    private GameObject muzzle;
    [SerializeField]
    private GameObject bullet;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("HAI THERE");
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
    }
}
