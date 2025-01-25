using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Material hitMaterial; // Assign a different material in the Inspector
    public Material originalMaterial;
    public bool isHit = false; // Flag to track if the enemy has been hit


    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            ChangeColor();
            isHit = true;
        }

        if (collision.gameObject.CompareTag("Player") && isHit)
        {
            Destroy(gameObject); 
        }
    }

    void ChangeColor()
    {
        // Change the enemy's material to the new material
        GetComponent<Renderer>().material = hitMaterial;
    }
}
