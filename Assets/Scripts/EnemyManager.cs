using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public Enemy[] enemies;

    public GameObject gate;
    
    // Start is called before the first frame update
    void Start()
    {
        
        gate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemies = Enemy.FindObjectsOfType<Enemy>();

        if (enemies.Length <= 0)
        {
            gate.SetActive(true);
        }
    }

    
}
