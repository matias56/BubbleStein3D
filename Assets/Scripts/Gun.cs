using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject spherePrefab; // Assign your sphere prefab in the Inspector
    public float launchForce = 10f; // Adjust the force of the sphere


    public float fireRate;

    private float nextTimeToFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    private void Fire()
    {

        nextTimeToFire = Time.time + fireRate;

        // Instantiate the sphere at the player's position and rotation
        GameObject sphere = Instantiate(spherePrefab, transform.position, transform.rotation);

        // Get the Rigidbody component of the spawned sphere
        Rigidbody rb = sphere.GetComponent<Rigidbody>();

        // Apply force to the sphere in the forward direction
        rb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
    }

    
}
