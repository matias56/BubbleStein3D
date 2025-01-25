using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public List<Enemy> enemiesInTrigger = new List<Enemy>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEnemy(Enemy enemy)
    {
        enemiesInTrigger.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemiesInTrigger.Add(enemy);
    }
}
